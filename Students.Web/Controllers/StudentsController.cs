using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Web.Entities;
using Students.Web.Infrastructure;
using Students.Web.ViewModel;

namespace Students.Web.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly StudentsContext _context;
        private readonly IMapper _mapper;

        public StudentsController(StudentsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("list")]
        public async Task<ActionResult<StudentDto[]>> Get(CancellationToken token)
        {
            var entities = await _context.Students.Where(s => !s.IsDeleted).ToArrayAsync();
            return entities.Select(e => _mapper.Map<StudentDto>(e)).ToArray();
        }

        [Route("{id:int}")]
        public async Task<ActionResult<StudentDto>> Get(int id, CancellationToken token)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == id);
            if (entity == null)
                return new NotFoundResult();
            return _mapper.Map<StudentDto>(entity);
        }

        public async Task<ActionResult<StudentDto>> Put([FromBody]StudentDto studentDto, CancellationToken token)
        {
            var entity = _mapper.Map<Student>(studentDto);
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return studentDto;
        }

        public async Task<ActionResult<StudentDto>> Post([FromBody]StudentDto studentDto, CancellationToken token)
        {
            var entity = _mapper.Map<Student>(studentDto);
            var student = _context.Students.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentDto>(student.Entity);
        }

        [Route("{id:int}")]
        public async Task<ActionResult<int>> Delete(int id, CancellationToken token)
        {
            var entity = new Student { Id = id, IsDeleted = true };
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}

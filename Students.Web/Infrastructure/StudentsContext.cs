using System;
using Microsoft.EntityFrameworkCore;
using Students.Web.Entities;

namespace Students.Web.Infrastructure
{
    public class StudentsContext : DbContext
    {
        public StudentsContext()
        {
        }

        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
    }
}

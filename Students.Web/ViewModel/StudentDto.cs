using System;
namespace Students.Web.ViewModel
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BirthYear { get; set; }

        public decimal? AverageMark { get; set; }
    }
}

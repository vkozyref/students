using System;
using System.ComponentModel.DataAnnotations;

namespace Students.Web.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BirthYear { get; set; }

        public bool IsDeleted { get; set; }

        public decimal? AverageMark { get; set; }
    }
}

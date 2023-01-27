using System;
using System.Collections.Generic;

namespace Labb_3_Anropa_Databasen_SQL_och_ORM.Models
{
    public partial class Course
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}

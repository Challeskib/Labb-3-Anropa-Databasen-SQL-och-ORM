using System;
using System.Collections.Generic;

namespace Labb_3_Anropa_Databasen_SQL_och_ORM.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Grades = new HashSet<Grade>();
        }

        public int TeacherId { get; set; }
        public int StaffId { get; set; }

        public virtual staff Staff { get; set; } = null!;
        public virtual ICollection<Grade> Grades { get; set; }
    }
}

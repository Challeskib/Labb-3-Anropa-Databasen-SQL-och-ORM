using System;
using System.Collections.Generic;

namespace Labb_3_Anropa_Databasen_SQL_och_ORM.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int Grade1 { get; set; }
        public DateTime DateOfGrade { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}

﻿using System;
using System.Collections.Generic;

namespace Labb_3_Anropa_Databasen_SQL_och_ORM.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalId { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Class { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}

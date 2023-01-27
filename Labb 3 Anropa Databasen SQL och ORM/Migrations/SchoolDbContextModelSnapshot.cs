﻿// <auto-generated />
using System;
using Labb_3_Anropa_Databasen_SQL_och_ORM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb_3_Anropa_Databasen_SQL_och_ORM.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfGrade")
                        .HasColumnType("date");

                    b.Property<int>("Grade1")
                        .HasColumnType("int")
                        .HasColumnName("Grade");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("GradeId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StaffId");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Class")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"), 1L, 1);

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.HasIndex("StaffId");

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Grade", b =>
                {
                    b.HasOne("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_Grade_Course");

                    b.HasOne("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Grade_Student");

                    b.HasOne("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Teacher", "Teacher")
                        .WithMany("Grades")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("FK_Grade_Teacher");

                    b.Navigation("Course");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Teacher", b =>
                {
                    b.HasOne("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Staff", "Staff")
                        .WithMany("Teachers")
                        .HasForeignKey("StaffId")
                        .IsRequired()
                        .HasConstraintName("FK_Teacher_Staff");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Course", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Staff", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("Labb_3_Anropa_Databasen_SQL_och_ORM.Models.Teacher", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
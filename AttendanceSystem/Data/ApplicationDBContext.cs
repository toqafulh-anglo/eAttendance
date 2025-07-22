using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Models;

namespace AttendanceSystem.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {

        }

        public DbSet<PASSDatas> PassData { get; set; }
        public virtual DbSet<PASSDatas> PassDataExec { get; set; }
        public DbSet<Student_Images> Student_Image { get; set; }
        public DbSet<Attendances> Attendance { get; set; }
        public virtual DbSet<Attendances> AttPresentAll { get; set; }

        public DbSet<AttendanceRecords> AttendanceRecord { get; set; }
        public DbSet<Contact_Informations> Contact_Information { get; set; }
        public DbSet<Teacher_Pictures> Teacher_Picture { get; set; }

        public DbSet<Notes_Status> NoteStatus { get; set; }
        public DbSet<Notes_Table> NotesTable { get; set; }
        public DbSet<Attendance_Report_Pivots> AttendanceReport_Pivot { get; set; }
        public DbSet<Summary1> Summary { get; set; }
        public DbSet<SubjectsCounts> SubjectCount { get; set; }
        public DbSet<Teacher_Attendance_Report_Pivot> TeacherAttendanceReportPivot { get; set; }
        public DbSet<Timetable_Links> TimetableLinks { get; set; }
        public DbSet<C64AttendanceRims> Campus64AttendanceRims { get; set; }

        public DbSet<vwTeacherTracking> TeacherTracking { get; set; }
        public DbSet<vwTeacherDepartment> TeacherDepartment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance_Report_Pivots>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<PASSDatas>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<Student_Images>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<Summary1>(eb =>
            {
                eb.HasNoKey();

            });

            modelBuilder.Entity<SubjectsCounts>(eb =>
            {
                eb.HasNoKey();

            });



            modelBuilder.Entity<Contact_Informations>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<Teacher_Pictures>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<Teacher_Attendance_Report_Pivot>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<Timetable_Links>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<C64AttendanceRims>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<vwTeacherTracking>(eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<vwTeacherDepartment>(eb =>
            {
                eb.HasNoKey();
            });
        }
    }
}

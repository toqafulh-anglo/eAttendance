using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceSystem.iRepository
{
    interface iRepositoryCRUD
    {
    }

    //PASSDATA
    public interface iRepositoryPASSData
    {
        public Task<List<PASSDatas>> GetTeacherClass(string Code);
        public Task<Boolean> CheckTeacherOK(string Code);
        public Task<PASSDatas> GetTeacherCode(string code);
        public Task<List<PASSDatas>> GetStudentList(string SubjectName, string TCode);
        public Task<PASSDatas[]> Addsession(string Subject);
    }



    //Student_Image
    public interface iRepositoryStudent_Image
    {
        public Task<Student_Images> GetStudentImage(string Scode);
    }

    //Teacher_Image
    public interface iRepositoryTeacher_Picture
    {
        public Task<Teacher_Pictures> GetTeacherPicture(string Tcode);
    }

    //Attendance
    public interface iRepositoryAttendance
    {
        public Task<Attendances> GetCurrentAttendance(string Scode, string Subject, string TCode);

        public Task<List<Attendances>> GetStudentAttendanceRemarks(string Scode);

        public Task<List<Attendances>> GetStudentAttendanceNORemarks(string Scode);

        public Task UpdateAttendance(Attendances upAtts);
        public Task<Boolean> CheckAttendance(string Scode, string Subject, string TName);

        public Task AddNewAttendance(String Scode, String SubjectClass, String Tname, String Status, String IPAddress);

        public Task<Attendances[]> AddPresentAlls(String Subject, String Teacher, String IPS, String Status, String Notes);
        public Task<Attendances> GetAttendanceNotes(string Scode, string SubjectClass, string TName);


    }

    //AttendanceRecord
    public interface iRepositoryAttendanceRecord
    {
        public Task UpdateAttendanceRecord(AttendanceRecords upAttRecs);
        public Task AddNewAttendanceRecord(String Scode, String SubjectClass, String Tname, String Status, String IPAddress);

        public Task<Boolean> CheckAttendanceRecord(string Scode, string Subject, string TName, DateTime Currdate);

        public Task<AttendanceRecords> GetCurrentAttendanceRecord(string Scode, string Subject, string TName,DateTime CurrDate);

        public Task<AttendanceRecords> GetAttendanceRecordNotes(string SCode, string SubjectClass, string TName, DateTime Currdate);
    }

    public interface iRepository64AttendanceRims
    {
        public Task<C64AttendanceRims> GetrimsAttendance(string scode);
        public Task<List<C64AttendanceRims>> GetAttendanceRimsList(string scode);
    
    }

    // Teacher Attendance Report
    public interface iRepositoryTeacher_Attendance
    {
        public Task<List<vwTeacherDepartment>> getTeacherDepartment(DateTime currentDate, string campus);
        public Task<List<vwTeacherTracking>> getTeachers(DateTime currentDate, string deptname, string campus);

    }


}

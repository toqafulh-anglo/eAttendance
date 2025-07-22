using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;
using AttendanceSystem.iRepository;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceSystem.Repository
{
    public class RepositoryCRUD
    {
    }

    //PASSDATA
    public class RepositoryPASSData : iRepositoryPASSData
    {
        private readonly ApplicationDBContext _db;

        public RepositoryPASSData(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckTeacherOK(string Code)
        {
            try
            {
                var iii = await _db.PassData.Where(s => s.TCode == Code).FirstOrDefaultAsync();
                if (iii != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public async  Task<List<PASSDatas>> GetTeacherClass(string Code)
        {
            try
            {
                
                //var iii = await _db.PassData.Where(s => s.TCode == Code).ToListAsync();       
                 var iii = await _db.PassData.Where(s => s.TCode == Code)
                    .Select(s => new PASSDatas
                    { 
                      
                        DESCRIPTION = s.DESCRIPTION,
                        TCode = s.TCode,
                        TName = s.TName
                    })
                    .Distinct()
                    .ToListAsync();

                return iii; 
            }
            catch
            {
                throw;
            }
        }

        public async Task<PASSDatas> GetTeacherCode(string code)
        {
           try
            {
                var user = await _db.PassData.FirstOrDefaultAsync(s => s.TCode == code);
                return user;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PASSDatas>> GetStudentList(string SubjectName, string TCode)
        {
            try
            {
                var students = await _db.PassData.OrderBy(s => s.Class).Where(s => s.DESCRIPTION == SubjectName && s.TCode == TCode).ToListAsync();
                return students;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PASSDatas[]> Addsession(string Subject)
        {
           try
            {
                PASSDatas[] passdatass;
                passdatass = await _db.PassDataExec.FromSqlRaw("EXEC [dbo].[AddClassSession] @ClassDescription = '" + Subject + "'").ToArrayAsync();
                
                return passdatass;
            }
            catch
            {
                throw;
            }
        }
    }

    //TEACHER PICTURE
    public class RepositoryTeacherPicture : iRepositoryTeacher_Picture
    {
        private readonly ApplicationDBContext _db;

        public RepositoryTeacherPicture(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Teacher_Pictures> GetTeacherPicture(String Tcode)
        {
            try
            {
                var Teacher = await _db.Teacher_Picture.FirstOrDefaultAsync(s => s.TCode == Tcode);
                return Teacher;
            }
            catch
            {
                throw;
            }
        }
    }

    //StudentImage
    public class RepositoryStudent_Image : iRepositoryStudent_Image
    {
        private readonly ApplicationDBContext _db;

        public RepositoryStudent_Image(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Student_Images> GetStudentImage(string Scode)
        {
            try
            {
                var Student = await _db.Student_Image.FirstOrDefaultAsync(s => s.SCode == Scode);
                return Student;
            }
            catch
            {
                throw;
            }
        }
    }

    public class Repository64AttendanceRims : iRepository64AttendanceRims
    {
        private readonly ApplicationDBContext _db;

        public Repository64AttendanceRims(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<C64AttendanceRims> GetrimsAttendance(string scode)
        {
            try
            {
                var attendance = await _db.Campus64AttendanceRims.FirstOrDefaultAsync(s => s.PIN == scode);
                return attendance;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<C64AttendanceRims>> GetAttendanceRimsList(string scode)
        {
            try
            {
                var attendance = await _db.Campus64AttendanceRims.Where(s => s.PIN == scode).ToListAsync();
                return attendance;
            }
            catch
            {
                throw;
            }
        }
    }

    //Attendance
    public class RepositoryAttendance : iRepositoryAttendance
    {
        private readonly ApplicationDBContext _db;

        public RepositoryAttendance(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Attendances> GetCurrentAttendance(string Scode, string Subject, string TName)
        {
           try
            {
                var attend = await _db.Attendance.FirstOrDefaultAsync(s => s.StudentCode == Scode && s.SubjectClass == Subject && s.TeacherName == TName);
                return attend;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddNewAttendance(String Scode, String SubjectClass, String Tname, String Status, String IPAddress)
        {
            try
            {
                Attendances a = new Attendances
                {
                    TimeStamp = DateTime.Now,
                    CurrentDate = DateTime.Now.Date,
                    StudentCode = Scode,
                    SubjectClass = SubjectClass,
                    TeacherName = Tname,
                    STATUS = Status,
                    NOTES = "",
                    IPAddress = IPAddress

                };
                await _db.Attendance.AddAsync(a);
                await _db.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAttendance(Attendances upAtts)
        {
            try
            {
                _db.Attendance.Update(upAtts);
               await  _db.SaveChangesAsync();
                

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CheckAttendance(string Scode, string Subject, string TName)
        {
            try
            {
                var iii = await _db.Attendance.Where(s => s.StudentCode == Scode && s.SubjectClass == Subject && s.TeacherName == TName).FirstOrDefaultAsync();
                if (iii != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Attendances[]> AddPresentAlls(string Subject, string Teacher, string IPS, string Status, string Notes)
        {
            try
            {
                Attendances[] attendance;
                attendance = await _db.AttPresentAll.FromSqlRaw("EXEC [dbo].[AttendanceAll] @SubjectName = '" + Subject + "', @Teacher = '"+ Teacher +"',@IPAddress = '"+ IPS +"',@Status = '"+ Status +"', @Notes = '"+ Notes +"'").ToArrayAsync();

                return attendance;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Attendances> GetAttendanceNotes(string Scode, string SubjectClass, string TName)
        {
            try
            {
                var iii = await _db.Attendance.Where(s => s.StudentCode == Scode && s.SubjectClass == SubjectClass && s.TeacherName == TName).FirstOrDefaultAsync();
                return iii;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Attendances>> GetStudentAttendanceRemarks(string Scode)
        {
            try
            {
                var students = await _db.Attendance.OrderBy(a => a.TimeStamp).Where(s => s.StudentCode == Scode && s.NOTES != " ").ToListAsync();
                return students;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Attendances>> GetStudentAttendanceNORemarks(string Scode)
        {
            try
            {
                var students = await _db.Attendance.OrderBy(a => a.TimeStamp).Where(s => s.StudentCode == Scode).ToListAsync();
                return students;
            }
            catch
            {
                throw;
            }
        }
    }


    //AttendaneRecord
    public class RepositoryAttendanceRecord : iRepositoryAttendanceRecord
    {
        private readonly ApplicationDBContext _db;

        public RepositoryAttendanceRecord(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task AddNewAttendanceRecord(string Scode, string SubjectClass, string Tname, string Status, string IPAddress)
        {
            try
            {
                AttendanceRecords a = new AttendanceRecords
                {
                    TimeStamp = DateTime.Now,
                    CurrentDate = DateTime.Now.Date,
                    StudentCode = Scode,
                    SubjectClass = SubjectClass,
                    TeacherName = Tname,
                    STATUS = Status,
                    NOTES = "",
                    IPAddress = IPAddress

                };
                await _db.AttendanceRecord.AddAsync(a);
                await _db.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAttendanceRecord(AttendanceRecords upAttRecs)
        {
            try
            {
                upAttRecs.CurrentDate = DateTime.Now.Date;
                _db.AttendanceRecord.Update(upAttRecs);
                await _db.SaveChangesAsync();


            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CheckAttendanceRecord(string Scode, string Subject, string TName, DateTime Currdate)
        {
            try
            {
                var iii = await _db.AttendanceRecord.Where(s => s.StudentCode == Scode && s.SubjectClass == Subject && s.TeacherName == TName && s.CurrentDate == Currdate).FirstOrDefaultAsync();
                if (iii != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<AttendanceRecords> GetCurrentAttendanceRecord(string Scode, string Subject, string TName, DateTime CurrDate)
        {
            try
            {
                var attend = await _db.AttendanceRecord.FirstOrDefaultAsync(s => s.StudentCode == Scode && s.SubjectClass == Subject && s.TeacherName == TName && s.CurrentDate == CurrDate);
                return attend;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AttendanceRecords> GetAttendanceRecordNotes(string SCode, string SubjectClass, string TName, DateTime Currdate)
        {
            try
            {
                var iii = await _db.AttendanceRecord.FirstOrDefaultAsync(s => s.StudentCode == SCode && s.SubjectClass == SubjectClass && s.TeacherName == TName && s.CurrentDate == Currdate);
                return iii;
            }
            catch
            {
                throw;
            }
        }
    }

    // Teacher Attendance Report

    public class RepositoryTeacherAttendance : iRepositoryTeacher_Attendance
    {
        private readonly ApplicationDBContext _db;

        public RepositoryTeacherAttendance(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<vwTeacherDepartment>> getTeacherDepartment(DateTime currentDate, string campus)
        {
            try
            {
                return await _db.TeacherDepartment.FromSqlRaw("EXEC [dbo].[TeacherDepartment] '" + currentDate + "','"+ campus + "'").ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<vwTeacherTracking>> getTeachers(DateTime currentDate, string deptname, string campus)

        {
            try
            {
                return await _db.TeacherTracking.FromSqlRaw("EXEC [dbo].[TeacherTracking] '" + currentDate + "','" + deptname + "','" + campus + "'").ToListAsync();
            }
            catch
            {
                throw;
            }
        }

    }


}


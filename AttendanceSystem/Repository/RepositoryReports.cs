using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;
using AttendanceSystem.Data;
using AttendanceSystem.iRepository;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Repository
{
    public class RepositoryReports : iRepositoryReports
    {
        private readonly ApplicationDBContext _db;

        public RepositoryReports(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Attendance_Report_Pivots>> GetReports()
        {
           try
            {
                return await _db.AttendanceReport_Pivot.OrderBy(s => s.Date_Time).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Attendance_Report_Pivots>> GetReportsperCampus(string Campus)
        {
            try
            {
                return await _db.AttendanceReport_Pivot.Where(s => s.Campus == Campus).OrderBy(s => s.DESCRIPTION).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Attendance_Report_Pivots>> GetReportsPerDateCampus(string Campus, DateTime CurrDate)
        {
            try
            {
                return await _db.AttendanceReport_Pivot.Where(s => s.Campus == Campus && s.CurrentDate == CurrDate).OrderBy(s => s.DESCRIPTION).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }



    public class RepositoryNotesTable : iRepositoryNotesTable
    {
        private readonly ApplicationDBContext _db;

        public RepositoryNotesTable(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Notes_Table> GetNotes(int Scode, DateTime dateTime)
        {
           try
            {
                var iii = await _db.NotesTable.Where(s => s.StudentID == Scode && s.NotedDate == dateTime).FirstOrDefaultAsync();
                return iii;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddNotes(string Status, string Comment, int Scode, DateTime NoteDate)
        {
            try
            {
                Notes_Table a = new Notes_Table
                {
                    Note_Status = Status,
                    Note_Text = Comment,
                    StudentID = Scode,
                    TimeStamp = DateTime.Now,
                    NotedDate = NoteDate

                };
                await _db.NotesTable.AddAsync(a);
                await _db.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateNotes(Notes_Table upNotes)
        {
            try
            {
                upNotes.TimeStamp = DateTime.Now;
                _db.NotesTable.Update(upNotes);
                await _db.SaveChangesAsync();


            }
            catch
            {
                throw;
            }
        }
    }



    public class RepositoryNotesStatus : iRepositoryNotesStatus
    {
        private readonly ApplicationDBContext _db;

        public RepositoryNotesStatus(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Notes_Status>> GetNoteList()
        {
            try
            {
                return await _db.NoteStatus.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }

    public class RepositorySummary : iRepositorySummary
    {
        private readonly ApplicationDBContext _db;

        public RepositorySummary(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Summary1>> GetSummaryList(string Campus, DateTime Date1, DateTime Date2)
        {
            try
            {
                return await _db.Summary.OrderBy(s => s.DESCRIPTION).Where(s => s.Campus == Campus && s.DATE1 == Date1 && s.DATE2 == Date2).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }

    public class RepositorySubjectCount : iRepositorySubjectCount
    {
        private readonly ApplicationDBContext _db;

        public RepositorySubjectCount(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<SubjectsCounts>> GetSubjectCount(DateTime CurrDate, string Scode)
        {
            try
            {
                return await _db.SubjectCount.Where(s => s.CurrentDate == CurrDate && s.StudentCode == Scode).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }


    public class RepositoryTeacherReports : iRepositoryTeacherReports
    {
        private readonly ApplicationDBContext _db;

        public RepositoryTeacherReports(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Teacher_Attendance_Report_Pivot>> GetSpecificDepartment(string Campus)
        {
            try
            {
                var list = await _db.TeacherAttendanceReportPivot.Where(s => s.Campus == Campus)
                .Select(s => new Teacher_Attendance_Report_Pivot
                {
                    Campus = s.Campus,
                    Department = s.Department
                }).Distinct().OrderBy(s => s.Department).ToListAsync();

                return list;


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Teacher_Attendance_Report_Pivot>> GetTeacherAttendanceReport(string department, string Campus, DateTime Currdate)
        {
            try
            {
                return await _db.TeacherAttendanceReportPivot.Where(s => s.Campus == Campus && s.Department.Contains(department) && s.CurrentDate == Currdate).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Timetable_Links>> GetSpecificLink(string department, string Campus)
        {
            try
            {
                return await _db.TimetableLinks.Where(s => s.Campus == Campus && s.Department == department).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}


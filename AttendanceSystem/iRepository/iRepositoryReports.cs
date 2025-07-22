using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;

namespace AttendanceSystem.iRepository
{
    public interface iRepositoryReports
    {
        public Task<List<Attendance_Report_Pivots>> GetReports();
        public Task<List<Attendance_Report_Pivots>> GetReportsperCampus(String Campus);
        public Task<List<Attendance_Report_Pivots>> GetReportsPerDateCampus(String Campus, DateTime CurrDate);

    }

    public interface iRepositoryTeacherReports
    {
        public Task<List<Teacher_Attendance_Report_Pivot>> GetSpecificDepartment(string Campus);
        public Task<List<Teacher_Attendance_Report_Pivot>> GetTeacherAttendanceReport(string department, string Campus, DateTime Currdate);

        public Task<List<Timetable_Links>> GetSpecificLink(string department, string Campus);
    }
    
    public interface iRepositoryNotesTable
    {
        public Task<Notes_Table> GetNotes(int Scode, DateTime dateTime);
        public Task AddNotes(String Status, String Comment, int Scode, DateTime NoteDate);
        public Task UpdateNotes(Notes_Table upNotes);
    }

    public interface iRepositoryNotesStatus
    {
        public Task<List<Notes_Status>> GetNoteList();
    }

    public interface iRepositorySummary
    {
        public Task<List<Summary1>> GetSummaryList(string Campus, DateTime Date1, DateTime Date2);
    }

    public interface iRepositorySubjectCount
    {
        public Task<List<SubjectsCounts>> GetSubjectCount(DateTime CurrDate, String Scode);
    }
}

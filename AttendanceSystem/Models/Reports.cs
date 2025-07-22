using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class Reports
    {
    }

    public class Notes_Status
    {
        [Key]
        public int ID { get; set; }
        public String DESCRIPTION { get; set; } = "";

    }


    public class Notes_Table
    {
        [Key]
        public int NID { get; set; }
        public String Note_Status { get; set; } = "";
        public String Note_Text { get; set; } = "";
        public int StudentID { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public DateTime NotedDate { get; set; } = DateTime.Now.Date;
    }

    public class Attendance_Report_Pivots
    {
        public String? Date_Time { get; set; } = "";
        public DateTime CurrentDate { get; set; } = DateTime.Now.Date;
        public String? Campus { get; set; } = "";
        public String? DESCRIPTION { get; set; } = "";
        public String? StudentCode { get; set; } = "";
        public String? SName { get; set; } = "";
        public String? Note_Status { get; set; } = "";
        public String? Note_Text { get; set; } = "";
        public String? Class1 { get; set; } = "";
        public String? Class2 { get; set; } = "";
        public String? Class3 { get; set; } = "";
        public String? Class4 { get; set; } = "";
        public String? Class5 { get; set; } = "";
        public String? Class6 { get; set; } = "";
        public String? Class7 { get; set; } = "";
        public String? Class8 { get; set; } = "";
        public String? Class9 { get; set; } = "";

    }

    public class Summary1
    {
        public DateTime DATE1 { get; set; } = DateTime.Now.Date;
        public DateTime DATE2 { get; set; } = DateTime.Now.Date;
        public String Campus { get; set; } = "";
        public String DESCRIPTION { get; set; } = "";
        public int TotalStudents { get; set; }
        public int? TotalPresent { get; set; }
        public int? TotalAbsent { get; set; }
    }

    public class SubjectsCounts
    {
        public DateTime CurrentDate { get; set; } = DateTime.Now.Date;
        public string StudentCode { get; set; } = "";
        public string SNickname { get; set; } = "";
        public string DESCRIPTION { get; set; } = "";
        public int TotalSubjects { get; set; }
        public int TotalPresent { get; set; }
        public int TotalAbsent { get; set; }
        public int TotalLate { get; set; }
    }

    public class Teacher_Attendance_Report_Pivot
    {
        public string? Date_Time { get; set; } = "";
        public DateTime? CurrentDate { get; set; } = DateTime.Now.Date;
        public string? Campus { get; set; } = "";
        public string? Department { get; set; } = "";
        public string? TCode { get; set; } = "";
        public string? TName { get; set; } = "";
        public String? Class1 { get; set; } = "";
        public String? Class2 { get; set; } = "";
        public String? Class3 { get; set; } = "";
        public String? Class4 { get; set; } = "";
        public String? Class5 { get; set; } = "";
        public String? Class6 { get; set; } = "";
        public String? Class7 { get; set; } = "";
        public String? Class8 { get; set; } = "";
        public String? Class9 { get; set; } = "";
        public String? Class10 { get; set; } = ""; 
        public String? Class11 { get; set; } = ""; 
        public String? Class12 { get; set; } = "";
    }

    public class Timetable_Links
    {
        public String? Campus { get; set; } = "";
        public String? Department { get; set; } = "";
        public String? TimetableLink { get; set; } = "";
    }

    
}

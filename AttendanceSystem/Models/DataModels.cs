using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceSystem.Models
{
    public class DataModels
    {
    }

    [Table("PASSData")]
    public class PASSDatas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Campus { get; set; } = "";
        public string SCode { get; set; } = "";
        public string SNickname { get; set; } = "";
        public string SName { get; set; } = "";
        public string Subject { get; set; } = "";
        public string TCode { get; set; } = "";
        public string TName { get; set; } = "";
        public string TNickname { get; set; } = "";

        public string Class { get; set; } = "";
        public string HName { get; set; } = "";
        public string HNickname { get; set; } = "";

        public string DESCRIPTION { get; set; } = "";
        public string SUBJECT_SET_ID { get; set; } = "";

    }




    [Table("Student_Image")]
    public class Student_Images
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? SCode { get; set; } = "";
        public string? SNickname { get; set; } = "";
        public string? SName { get; set; } = "";
        public byte[]? SPicture { get; set; }
        public string? EmailAddress { get; set; } = "";

    }

    [Table("Attendance")]
    public class Attendances
    {
        [Key]
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public DateTime CurrentDate { get; set; } = DateTime.Now.Date;
        public string StudentCode { get; set; } = "";
        public string SubjectClass { get; set; } = "";
        public string TeacherName { get; set; } = "";
        public string STATUS { get; set; } = "";
        public string NOTES { get; set; } = "";
        public string IPAddress { get; set; } = "";

    }

    [Table("AttendanceRecord")]
    public class AttendanceRecords
    {
        [Key]
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public DateTime CurrentDate { get; set; } = DateTime.Now.Date;
        public string StudentCode { get; set; } = "";
        public string SubjectClass { get; set; } = "";
        public string TeacherName { get; set; } = "";
        public string STATUS { get; set; } = "";
        public string NOTES { get; set; } = "";
        public String IPAddress { get; set; } = "";

    }

    [Table("Contact_Information")]
    public class Contact_Informations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string DESCRIPTION { get; set; } = "";
        public string Code { get; set; } = "";
        public string StudentName { get; set; } = "";
        public string Mother_Name { get; set; } = "";
        public string Mother_Surname { get; set; } = "";
        public string Mother_Telephone { get; set; } = "";
        public string Mother_Email_Address { get; set; } = "";
        public string Father_Name { get; set; } = "";
        public string Father_Surname { get; set; } = "";
        public string Father_Email_Address { get; set; } = "";
        public string Father_Telephone { get; set; } = "";

    }

    public class C64AttendanceRims
    {
        //public int? NAME_ID { get; set; }
        public String PIN { get; set; }
        public String? UserName { get; set; } = "";
        public String? DeptName { get; set; } = "";
        public String? DeptNameH { get; set; } = "";
        public DateTime inTime { get; set; } = DateTime.Now;
        //public String? DIVGROUP { get; set; } = "";

    }

    //  [Table("Teacher_Picture")]
    public class Teacher_Pictures
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TCode { get; set; } = "";
        public string TName { get; set; } = "";
        public string TNickname { get; set; } = "";
        public byte[] TPicture { get; set; }
        public string TEmail { get; set; } = "";

    }


    public class vwTeacherTracking
    {

        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Department { get; set; } = "";
    }

    public class vwTeacherDepartment
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Department { get; set; } = "";
    }


}

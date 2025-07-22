using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;

namespace AttendanceSystem.Data
{
    public class SCRUD
    {
    }

    public class Student_ImagesCRUD
    {
        private readonly ApplicationDBContext _db;
        public Student_ImagesCRUD(ApplicationDBContext db)
        {
            _db = db;
        }

        public Student_Images GetStudentImagesCRUD(string Scode)
        {
            try
            {
                var students = _db.Student_Image.FirstOrDefault(s => s.SCode == Scode);
                return students;
            }
            catch
            {
                throw;
            }
        }

    }

   
}

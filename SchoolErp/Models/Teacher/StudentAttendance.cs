using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Teacher
{
    public class StudentAttendance
    {
        public int AdmissionNo { get; set; }

        public string Studentname { get; set; }

        public DateTime Date { get; set; }

        public string Remark { get; set; }

        
    }
}
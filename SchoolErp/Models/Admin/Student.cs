using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class Student
    {
        public int AdmissionNo { get; set; }

        public string StudentName { get; set; }

        public DateTime DOB { get; set; }

        public string Nationality { get; set; }

        public string Gender { get; set; }

        public string Religion { get; set; }

        public int SessionID { get; set; }

        public string SessionName { get; set; }

        public string Term { get; set; }

        public string ClassLevel { get; set; }

        public int ClassLevelID { get; set; }

        public string ClassAphabet { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Fathername { get; set; }

        public string Mothername { get; set; }

        public string FatherPhone { get; set; }

        public string MotherPhone { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Teacher
{
    public class SubjectMark
    {
        public int ID { get; set; }

        public string Term { get; set; }

        public string SessionID { get; set; }

        public int SessionName { get; set; }

        public int SubjectID { get; set; }

        public string ClassLevelname { get; set; }

        public int ClassLevelID { get; set; }

        public string Subjectname { get; set; }

        public string StudentName { get; set; }

        public int AdmissionNo { get; set; }

        public int FirstCA { get; set; }

        public int SecondCA { get; set; }

        public int ThirdCA { get; set; }

        public int Exams { get; set; }



    }
}
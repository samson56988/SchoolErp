using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class AssignSubject
    {
        public int ID { get; set; }

        public int StaffID { get; set; }

        public string staffname { get; set; }

        public int SubjectID { get; set; }

        public string Subject { get; set; }

        public int ClassLevelID { get; set; }

        public string ClassLevelname { get; set; }

        public string Prefix { get; set; }

    }
}
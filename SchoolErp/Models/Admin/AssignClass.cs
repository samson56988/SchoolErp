using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class AssignClass
    {
        public int ID { get; set; }

        public int StaffID { get; set; }

        public string Staffname { get; set; }

        public int ClassLevelID { get; set; }

        public string ClassLevelName { get; set; }

        public string Prefix { get; set; }
    }
}
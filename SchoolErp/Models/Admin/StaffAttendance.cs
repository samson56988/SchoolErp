using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class StaffAttendance
    {
        public int ID { get; set; }

        public int StaffID { get; set; }

        public string Staffname { get; set; }

        public DateTime Date { get; set; }

        public string Remark { get; set; }
    }
}
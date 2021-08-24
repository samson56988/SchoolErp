using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class Staff
    {
        public int StaffID { get; set; }

        public string Staffname { get; set; }

        public string Gender { get; set; }

        public int DesignationID { get; set; }

        public string Designation { get; set; }

        public string Phone1 { get; set; }

        public string phone2 { get; set; }

        public string Email { get; set; }

        public string StaffAddress { get; set; }

        public DateTime DateOfAppointment { get; set; }

        public string Nationality { get; set; }

        public int YOE { get; set; }

        public string previouseOrg { get; set; }

        public string Resume { get; set; }

        public string AccountStatus { get; set; }

        public HttpPostedFileBase ResumeImageFile { get; set; }
        


    }
}
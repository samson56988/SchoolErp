using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class Role
    {
        public int RoleID { get; set; }

        public string Rolename { get; set; }

        public int StaffID { get; set; }

        public string Staffname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


    }
}
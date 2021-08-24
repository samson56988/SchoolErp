using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class Session
    {
        public int SessionID { get; set; }

        public string SessionName { get; set; }

        public string Term { get; set; }

        public string IsActive { get; set; }
    }
}
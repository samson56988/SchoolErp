using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class CollectFee
    {
        public int Id { get; set; }

        public int AdmissionNo { get; set; }

        public string StudentName { get; set; }

        public int ClassLevelID { get; set; }

        public string ClassLevelname { get; set; }

        public string Session { get; set; }

        public decimal Amount { get; set; }

        public string TellerNo { get; set; }

        public string Bank { get; set; }

        public DateTime Date { get; set; }

        
    }


}
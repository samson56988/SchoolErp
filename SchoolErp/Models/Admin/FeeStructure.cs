using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class FeeStructure
    {
        public int FeeStructureID { get; set; }

        public int FeeTypeID { get; set; }

        public string FeeTypename { get; set; }

        public int SectionID { get; set; }

        public string SectionName { get; set; }

        public decimal Amount { get; set; }
    }
}
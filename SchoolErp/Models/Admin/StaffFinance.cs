using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class StaffFinance
    {
        public int ID { get; set; }

        public int staffID { get; set; }

        public string StaffName { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal HouseAllowance { get; set; }

        public decimal TransportAllowance { get; set; }

        public decimal LateComingFee { get; set; }

        public decimal Tax { get; set; }

        public decimal Vat { get; set; }

        public decimal TotalPay { get; set; }
    }
}
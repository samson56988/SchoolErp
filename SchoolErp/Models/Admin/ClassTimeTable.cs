using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolErp.Models.Admin
{
    public class ClassTimeTable
    {
        public int ID { get; set; }

        public int ClassLevelID { get; set; }

        public string ClassLevelName { get; set; }

        public string Days { get; set; }

        public string Period1 { get; set; }
   
        public string Period2 { get; set; }
    
        public string Period3 { get; set; }        

        public string Period4 { get; set; }
 
        public string Period5 { get; set; }   

        public string Period6 { get; set; }

     

    }
}
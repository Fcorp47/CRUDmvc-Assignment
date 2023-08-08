using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Models
{
   
    public class Department
    {

        public int DID { get; set; }

        public string DeptName { get; set; }

        public SelectList DeptList { get; set; }
    }
}
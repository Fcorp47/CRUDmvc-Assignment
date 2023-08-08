using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public String FirstName { get; set; } 

        
        public String LastName { get; set; }

        [Required]
        public String Designation { get; set; }

        [Required]
        public int Department { get; set; }

        [Required]
        public String Knowledge { get; set; }
        
        [Required]
        public decimal Salary { get; set; }

        //   [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]

        [Required]
        public String JoinDate { get; set; }

       
        public String Report_person { get; set; }



            //join model member
        public String joindept { get; set; }


        public String joinreport { get; set; }
    }
   
}
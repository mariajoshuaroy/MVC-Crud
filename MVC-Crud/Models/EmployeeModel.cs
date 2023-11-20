using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Crud.Models
{
    public class EmployeeModel
    {
        public int id { get; set; }
        [StringLength(100)]


        public string EmpName { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Employee Name is required")]

        public string EmpNumber { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Employee Number is required")]

        public string EmpEmail { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Employee Email is required")]

        public string Address { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Employee Address is required")]

        public string BloodGroup { get; set; }

    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="This is required.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage ="This is required")]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required(ErrorMessage = "This is required.")]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "This is required.")]
        [MaxLength(50)]
        public string Designation { get; set; }
        [Required(ErrorMessage = "This is required.")]
       
        public float Salary { get; set; }
        [Required(ErrorMessage = "This is required.")]      
        public int MobileNo { get; set; }

      


    }
}

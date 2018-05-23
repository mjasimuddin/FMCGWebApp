using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMCGWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [EmailAddress]
        [Remote("IsEmailExists", "Admin", ErrorMessage = "Email Already Exists!")]
        public string Email { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string NationalIdNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
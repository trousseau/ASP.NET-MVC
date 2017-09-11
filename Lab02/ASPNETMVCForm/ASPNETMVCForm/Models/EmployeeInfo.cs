using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCForm.Models
{
    public enum Gender
    {
        Female,Male
    }
    public class EmployeeInfo
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Given Name")]
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
        [Display(Name = "Annual Salary")]
        [Range(1,200000)]
        public double AnnualSalary { get; set; }
        [Display(Name = "Department")]
        [Range(1,1000)]
        public int DepartmentId { get; set; }
    }
}
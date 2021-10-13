using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TadaEntryWebApp.Models
{
    public class Tada
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please Select a Date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Please Select an Employee")]
        [Display(Name = "Employee Name   ")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Travel Cost")]
        public int TravelCost { get; set; }

        [Required]
        [Display(Name = "Lunch Cost")]
        public int LunchCost { get; set; }

        [Required]
        [Display(Name = "Instrument Cost   ")]
        public int InstrumentCost { get; set; }

        [Required(ErrorMessage = "Please Select If it's paid or not")]
        [Display(Name = "Is Paid")]
        public bool IsPaid { get; set; }
        
        
    }
}
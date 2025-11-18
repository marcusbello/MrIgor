using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MrIgor.Mvc.Models
{
    public class OnBoardingIndexViewModel
    {
        public string SelectedPlan { get; set; } = null!;
        public string BillingOption { get; set; } = null!;
        public string SchoolName { get; set; } = null!;
        public string SchoolType { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? TeacherName { get; set; }
        public string? TeacherEmail { get; set; }
    }
}
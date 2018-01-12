using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Controllers.Resources
{
    public class SaveAppointmentResource
    {
        [Required(ErrorMessage = "Invalid Visitor reference number")]
        public string VisitorRef { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public string StartDate {get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public string EndDate { get; set; }

        [Required(ErrorMessage = "Group Visit is required")]
        public string IsGroupVisit { get; set; }

        [Required(ErrorMessage = "What's the floor number")]
        public int FloorNumber { get; set; }

        [Required(ErrorMessage = "Purpose of visit")]
        public int PurposeOfVisit { get; set; }

        public string Instruction { get; set; }

        [Required(ErrorMessage = "Valid Staff is requied")]
        public string StaffId { get; set; }

    }
}

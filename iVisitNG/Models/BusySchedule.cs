using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iVisitNG.Models
{
    public class BusySchedule
    {
        [Key]
        public int Id { get; set; }

        public string StaffId { get; set; }

        [Required, StringLength(255), Display(Name = "Out of Office/Busy Reason")]
        public string Reason { get; set; }

        [Display(Name = "From")]
        public DateTime FromDateTime { get; set; }

        [Display(Name = "To")]
        public DateTime ToDateTime { get; set; }

        [DataType(DataType.Date), Display(Name = "Created At")]
        public DateTime CreatedDate { get; set; }

        [Required, ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        public string ReasonText => Common.StripHtml(this.Reason);
    }
}
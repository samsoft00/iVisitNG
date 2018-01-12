using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models.ViewModels
{
    public class SchedulerFormModal
    {

        public string StaffId { get; set; }

        [Required, StringLength(255), Display(Name = "Out of Office/Busy Reason")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Please select Date From"), Display(Name = "Date From")]
        public string FromDateTime { get; set; }

        [Required(ErrorMessage = "Please select Date To"), Display(Name = "Date To")]
        public string ToDateTime { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Created At")]
        public DateTime CreatedDate { get; set; }

        public SchedulerFormModal()
        {
            
        }

        public SchedulerFormModal(BusySchedule busySchedule)
        {
            this.Reason = busySchedule.Reason;
            this.FromDateTime = busySchedule.FromDateTime.ToString();
            this.ToDateTime = busySchedule.ToDateTime.ToString();
        }
    }
}

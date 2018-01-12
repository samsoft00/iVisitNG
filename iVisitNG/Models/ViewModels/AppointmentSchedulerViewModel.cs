using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models.ViewModels
{
    public class AppointmentSchedulerViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Visitor> Visitors { get; set; }
        public AppointmentDateTime AppointmentDateTime { get; set; }
        public Visitor Visitor { get; set; }
        public IEnumerable<PurposeOfVisit> PurposeOfVisit { get; set; }
        [Display(Name = "Purpose of Visiting")]
        public string Purpose { get; set; }

        public StatisticViewModel stats { get; set; }
    }
}

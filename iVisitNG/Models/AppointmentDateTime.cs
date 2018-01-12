using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models
{
    public class AppointmentDateTime
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        [Required, Key, Column(Order = 1)]
        public virtual Appointment Appointment { get; set; }
    }
}

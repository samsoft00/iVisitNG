using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace iVisitNG.Models
{
    public class Appointment
    {

        public Appointment()
        {
            //this.VisitorItems = new List<VisitorItem>();
            //this.CheckIns = new List<CheckIns>();
        }

        public int Id { get; set; }
        public int VisitorId { get; set; }
        public string StaffId { get; set; }

        public int PurposeOfVisitId { get; set; }

        [Required, ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        [Required, ForeignKey("VisitorId")]
        public virtual Visitor Visitor { get; set; }

        [Required, ForeignKey("PurposeOfVisitId"), Column(Order = 3)]
        public PurposeOfVisit Purpose { get; set; }

        [Required, StringLength(150, MinimumLength = 5)]

        public string InstructionToSecurity { get; set; }

        public bool ApprovedStatus { get; set; }

        public int? FloorNumber { get; set; }

        public bool IsGroupVisit { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateAt { get; set; }

        public string barcode { get; set; }

        //public virtual ICollection<CheckIns> CheckIns { get; set; }
        //public virtual ICollection<VisitorItem> VisitorItems { get; set; }
    }
}

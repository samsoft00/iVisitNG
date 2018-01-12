using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        public string StaffId { get; set; }
        public int DivisionId { get; set; }

        [Display(Name = "Zonal Office")]
        public int ZonalOfficeId { get; set; }

        [Required, StringLength(150)]
        public string FirstName { get; set; }

        [Required, StringLength(150)]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [Required, DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }

        [Required, ForeignKey("ZonalOfficeId")]
        public ZonalOffice ZonalOffice { get; set; }

        [Required, ForeignKey("StaffId")]
        public Staff Staff { get; set; }

        [Required, ForeignKey("DivisionId")]
        public Division Division { get; set; }
    }
}

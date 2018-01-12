using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models
{
    [Table("Divisions")]
    public class Division
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter valid Division Name"), Display(Name = "Division Name")]
        public string DivisionName { get; set; }

    }
}

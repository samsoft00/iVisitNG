using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models
{
    public class ZonalOffice
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
    }
}

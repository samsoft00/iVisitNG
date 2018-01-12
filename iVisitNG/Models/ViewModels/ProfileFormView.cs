using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models.ViewModels
{
    public class ProfileFormView
    {
        [Display(Name = "Zonal Office")]
        public int ZonalOfficeId { get; set; }

        [Required, StringLength(150)]
        public string FirstName { get; set; }

        [Required, StringLength(150)]
        public string LastName { get; set; }
    }
}

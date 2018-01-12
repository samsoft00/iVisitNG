using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models.ViewModels
{
    public class ZonalOfficeView
    {
        [Required(ErrorMessage = "Enter Zone name"), StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
    }
}

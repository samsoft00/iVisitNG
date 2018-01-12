using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models
{
    public class PurposeOfVisit
    {
        [Key]
        public int Id { get; set; }
        public string purpose { get; set; }

    }
}

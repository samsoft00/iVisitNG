using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }

        public int DivisionId { get; set; }
        public int ZonalOfficeId { get; set; }

        public IEnumerable<Division> Divisions { get; set; }

        public IEnumerable<ZonalOffice> ZonalOffices { get; set; }

        public string StatusMessage { get; set; }
    }
}

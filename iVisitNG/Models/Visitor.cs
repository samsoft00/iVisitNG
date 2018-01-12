using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using iVisitNG.Models;

namespace iVisitNG.Models
{
    public class Visitor
    {

        public Visitor()
        {
            Staffs = new List<Appointment>();
        }

        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public int CountryId { get; set; }

        [Required, StringLength(100), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(100), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, DataType(DataType.PhoneNumber), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(100), Display(Name = "Ref. Number")]
        public string RefNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(255)]
        public string Company { get; set; }

        [Required, StringLength(255)]
        public string OfficeAddress { get; set; }

        [Required, DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public bool IsBlackListed { get; set; }

        public string FingerPrint { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Required, ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required, ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual ICollection<Appointment> Staffs { get; set; }

    }
}
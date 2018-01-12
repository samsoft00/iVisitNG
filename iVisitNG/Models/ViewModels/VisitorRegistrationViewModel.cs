using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
    
namespace iVisitNG.Models.ViewModels
{
    public class VisitorRegistrationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please select a Country")]
        public int Country { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select a Category")]
        public int Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        [Required, StringLength(100), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(100), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, DataType(DataType.PhoneNumber), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required, DataType(DataType.EmailAddress), Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Company Name")]
        public string Company { get; set; }

        [Required, Display(Name = "Company Address")]
        public string OfficeAddress { get; set; }

        public VisitorRegistrationViewModel(){}

        public VisitorRegistrationViewModel(Visitor visitor)
        {
            Id = visitor.Id;
            FirstName = visitor.FirstName;
            LastName = visitor.LastName;
            Email = visitor.Email;
            Company = visitor.Company;
            PhoneNumber = visitor.PhoneNumber;

        }

        public string GetImageUrl()
        {
            var path = "https://www.gravatar.com/avatar/";
            var hash = GetEMailHash(this.Email);

            return System.String.Concat(path, hash);
        }

        private string GetEMailHash(string emailAdress)
        {
            MD5 hasher = MD5.Create();
            byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(emailAdress));
            StringBuilder sb = new StringBuilder();

            foreach (byte d in data)
                sb.Append(d.ToString("x2"));

            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace iVisitNG.Models
{
    // Add profile data for application users by adding properties to the Staffs class
    public class Staff : IdentityUser
    {
        //Add new field(s) to User here
        public Staff()
        {
            this.Visitors = new List<Appointment>();
        }

        [Required]
        [DefaultValue(false)]
        public bool IsProfileSetUp { set; get; }

        public ICollection<Appointment> Visitors { get; set; }
    }
    
}

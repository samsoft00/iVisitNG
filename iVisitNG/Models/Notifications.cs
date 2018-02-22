using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models
{
    [Table("Notification")]
    public class Notifications
    {
        public int Id { get; set; }

        public string PostedById { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [ForeignKey("PostedById")]
        public Staff PostedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string MessageText => Common.StripHtml(this.Message);
        
    }
}

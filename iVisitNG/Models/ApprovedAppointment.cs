//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iVisitNG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ApprovedAppointment
    {
        [Key]
        public int ApproveID { get; set; }
        public int AppID { get; set; }
        public string StaffID { get; set; }
        public System.DateTime CreatedAt { get; set; }
    }
}

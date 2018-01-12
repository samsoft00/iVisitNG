using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iVisitNG.Models.ViewModels
{
    public class StatisticViewModel
    {
        /*
         * 1. Total Visitors
            2. Registered Staff
            3. Awaiting Appointments
            4. Zone/Tenants
         * 
         * */

        public int visitors { get; set; }
        public int staffs { get; set; }
        public int appointment { get; set; }
        public int tenants { get; set; }

    }
}

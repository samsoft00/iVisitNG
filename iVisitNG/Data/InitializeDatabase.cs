using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iVisitNG.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace iVisitNG.Data
{
    public class InitializeDatabase
    {
        private readonly ApplicationDbContext _db;

        public InitializeDatabase(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create()
        {;

            string[] roleNames = { "Admin", "Manager", "Staff", "Receiptionist" };

        }
    }
}

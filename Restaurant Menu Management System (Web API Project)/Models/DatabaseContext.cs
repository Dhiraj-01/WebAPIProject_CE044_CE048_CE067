using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Menu_Management_System__Web_API_Project_.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DatabaseContext() : base("ItemCS")
        {

        }
    }
}
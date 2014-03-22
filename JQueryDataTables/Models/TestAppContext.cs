using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JQueryDatatables.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JQueryDatatables.Models
{
    public class TestAppContext : DbContext
    {
        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
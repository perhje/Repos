using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Pizza.Models
{
    public class DB : DbContext
    {
        internal object Bestilling;

        public DB()
            : base("name=Bestilling")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Bestilling> Bestillinger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataMapping;
using Models;
using Db.DataMapping;

namespace Db
{
    /// <summary>
    ///     The context.
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class.
        /// </summary>
        public Context()
            : base("name=Vehicles")
        {
            // disable Lazy loading
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Stamp> Stamps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Disable Cascade Delete
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // to generate table in singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Settings Models
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new VehicleMap());

            base.OnModelCreating(modelBuilder);
        }

    }

}

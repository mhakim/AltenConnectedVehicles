using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping
{
    public class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            this.Property(v => v.Id).IsRequired().HasMaxLength(FieldLength.Id);
            this.Property(v => v.RegistrationNumber).HasMaxLength(FieldLength.Small);
        }
    }

}

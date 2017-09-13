using Models;
using System.Data.Entity.ModelConfiguration;

namespace DataMapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.Property(v => v.Id).IsRequired().HasMaxLength(FieldLength.Id);
            this.Property(v => v.Name).IsRequired().HasMaxLength(FieldLength.Small);
            this.Property(v => v.Address).HasMaxLength(FieldLength.Large);
        }
    }
}

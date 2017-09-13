using Models;
using System.Data.Entity.ModelConfiguration;

namespace Db.DataMapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.Property(v => v.Name).IsRequired().HasMaxLength(FieldLength.Small);
            this.Property(v => v.Address).HasMaxLength(FieldLength.Large);
        }
    }
}

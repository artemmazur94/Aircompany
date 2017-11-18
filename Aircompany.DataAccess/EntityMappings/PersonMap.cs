using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            HasKey(x => x.Id);

            HasOptional(x => x.Photo).WithMany(x => x.Persons).HasForeignKey(x => x.PhotoId);
        }
    }
}
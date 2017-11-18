using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class PersonLocalizationMap : EntityTypeConfiguration<PersonLocalization>
    {
        public PersonLocalizationMap()
        {
            HasKey(x => new {x.LanguageId, x.PersonId});

            HasRequired(x => x.Language).WithMany(x => x.PersonLocalizations).HasForeignKey(x => x.LanguageId);
            HasRequired(x => x.Person).WithMany(x => x.PersonLocalizations).HasForeignKey(x => x.PersonId);
        }
    }
}
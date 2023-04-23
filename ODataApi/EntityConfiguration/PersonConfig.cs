using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ODataApi.Models;

namespace ODataApi.EntityConfiguration
{
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}

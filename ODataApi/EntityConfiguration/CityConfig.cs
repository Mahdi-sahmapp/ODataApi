using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ODataApi.Models;

namespace ODataApi.EntityConfiguration
{
    internal class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}

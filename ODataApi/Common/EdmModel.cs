using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataApi.EntityType;
using ODataApi.Models;

namespace ODataApi.Common
{
    public class EdmModel
    {
        public static  IEdmModel GetEDMModel1()
        {
            ODataConventionModelBuilder builder1 = new();
            builder1.EntitySet<Person>("Person");
            builder1.EntitySet<Person>("City");
            return builder1.GetEdmModel();
        }

        // Second Method 
        public static IEdmModel GetEDMModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "ODataApi.Models";
            builder.ContainerName = "DefaultContainer";
            builder.EnableLowerCamelCase();

            foreach (var model_type in EntityTypes.model_types)
            {
                var entity_type = model_type.Key;
                EntityTypeConfiguration entityType = builder.AddEntityType(entity_type);
                builder.AddEntitySet(entity_type.Name, entityType);
            }

            return builder.GetEdmModel();
        }
    }
}

using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataApi.Models;

namespace ODataApi.Common
{
    public class EdmModel
    {
        public static  IEdmModel GetEDMModel()
        {
            ODataConventionModelBuilder builder1 = new();
            builder1.EntitySet<Person>("Person");
            builder1.EntitySet<Person>("City");
            return builder1.GetEdmModel();
        }
    }
}

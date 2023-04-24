using ODataApi.Dto;
using ODataApi.Models;
using System.Reflection;

namespace ODataApi.EntityType
{
    public static class EntityTypes
    {
        public static Dictionary<TypeInfo, List<TypeInfo>> model_types => new Dictionary<TypeInfo, List<TypeInfo>>()
         {
              { typeof(Person).GetTypeInfo(), new List<TypeInfo>() { typeof(PersonDto).GetTypeInfo(), typeof(PersonDto).GetTypeInfo() }},
              { typeof(City).GetTypeInfo(), new List<TypeInfo>() { typeof(CityDto).GetTypeInfo(), typeof(CityDto).GetTypeInfo() }},
         };
    }
}

using ODataApi.Dto;
using ODataApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
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

        public static Dictionary<Type, List<Type>> Getmodel_types3()       
        {

            Type[] q = Assembly.GetExecutingAssembly().GetTypes().Where(a => a.IsClass
            && a.IsVisible
            && a.Namespace == "ODataApi.Models").ToArray();
            Dictionary<Type, List<Type>> model_types1 = new();
            foreach (var item in q)
            {
                //Any(a=>a.AttributeType.Name =="TableAttribute")
                if (item.CustomAttributes.Any(a=>a.AttributeType == typeof(TableAttribute)))
                {

                }
                Type key = Type.GetType(item.Namespace + "." + item.Name + ",ODataApi") ?? throw new Exception("Assemblu not found");
                Type TResponse = Type.GetType(item.Namespace + "." + item.Name + ",ODataApi") ?? throw new Exception("Assemblu not found");
                Type TRequest = Type.GetType(item.Namespace + "." + item.Name + ",ODataApi") ?? throw new Exception("Assemblu not found");
                model_types1.Add(key, new List<Type> { TResponse, TRequest });
            }


            return model_types1;
        }
    }
}

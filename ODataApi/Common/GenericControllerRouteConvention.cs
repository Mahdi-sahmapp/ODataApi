using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ODataApi.Atttribute;
using System.Reflection;

namespace ODataApi.Common
{
    public class GenericControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                var customeNameAttribute = genericType.GetCustomAttribute<GeneratedControllerAttribute>();

                if (customeNameAttribute?.Route != null)
                {
                    controller.Selectors.Add(new SelectorModel
                    {
                        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customeNameAttribute.Route)),
                    });
                }
            }
        }
    }
}

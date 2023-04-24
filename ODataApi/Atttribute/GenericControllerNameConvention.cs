using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ODataApi.Controllers;

namespace ODataApi.Atttribute
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited =true)]
    public class GenericControllerNameConvention : Attribute,IControllerModelConvention
    {

        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType || controller.ControllerType.GetGenericTypeDefinition() != typeof(BaseController<,,>))
            {
                return;
            }
            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = entityType.Name;
            controller.RouteValues["Controller"] = entityType.Name;
        }
    }
}

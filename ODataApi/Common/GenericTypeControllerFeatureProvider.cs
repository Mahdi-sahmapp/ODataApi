﻿using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using ODataApi.Atttribute;
using ODataApi.Controllers;
using ODataApi.EntityType;
using System.Reflection;

namespace ODataApi.Common
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var model_type in EntityTypes.Getmodel_types3())
            {
                var entity_type = model_type.Key;
                var entity_request_types = model_type.Value[0];
                Type[] typeArgs = { entity_type, model_type.Value[0], model_type.Value[1] };
                var controller_type = typeof(BaseController<,,>).MakeGenericType(typeArgs).GetTypeInfo();
                feature.Controllers.Add(controller_type);
            }
        }
    }
}

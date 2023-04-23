namespace ODataApi.Atttribute
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public string Route { get; set; }
        public GeneratedControllerAttribute(string route)
        {
            Route = route;
        }
    }
}

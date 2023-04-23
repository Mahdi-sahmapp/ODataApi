using ODataApi.Atttribute;

namespace ODataApi.Dto
{
    [GeneratedController("api/person")]
    public class PersonDto
    {
        public string? Name { get; set; }
        public int? CityId { get; set; }
        public string? Phone { get; set; }
    }
}

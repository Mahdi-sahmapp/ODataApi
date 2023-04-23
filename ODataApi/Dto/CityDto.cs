using ODataApi.Atttribute;
using System.CodeDom.Compiler;

namespace ODataApi.Dto
{
    [GeneratedController("api/City")]
    public class CityDto
    {
        public string? City1 { get; set; }
        public byte? State { get; set; }
    }
}

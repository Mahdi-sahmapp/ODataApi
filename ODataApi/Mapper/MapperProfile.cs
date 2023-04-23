using AutoMapper;
using ODataApi.Dto;
using ODataApi.Models;

namespace ODataApi.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            //CreateMap<PersonDto, Person>().ReverseMap(); ;
            //CreateMap<CityDto, City>().ReverseMap();
        }
    }
}

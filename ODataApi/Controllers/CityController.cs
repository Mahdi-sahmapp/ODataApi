using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataApi.Dto;
using ODataApi.Models;
using ODataApi.Services;

namespace ODataApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CityController:ControllerBase
    {
        private IMapper _mapper;
        private readonly IRepository<City> _repository;

        public CityController(IMapper mapper, IRepository<City> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(IEnumerable<CityDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var city = await _repository.GetAll().ToListAsync(cancellationToken);

            if (!city.Any())
                return NotFound();

            var result = _mapper.Map<List<CityDto>>(city);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(CityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] CityDto entity, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var city = _mapper.Map<City>(entity);
            return Ok(await _repository.Add(city, cancellationToken));
        }
    }
}

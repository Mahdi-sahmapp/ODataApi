using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ODataApi.Dto;
using ODataApi.Models;
using ODataApi.Services;

namespace ODataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PersonController : ControllerBase
    {

        private IMapper _mapper;
        private readonly IRepository<Person> _repository;

        public PersonController(IMapper mapper, IRepository<Person> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [EnableQuery]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(IEnumerable<Person>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Getall(CancellationToken cancellationToken)
        {
            var person = await _repository.GetAll().Include(a=>a.City).ToListAsync(cancellationToken);

            return Ok(person);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int Id,CancellationToken cancellationToken)
        {
            if(Id == 0)
                return NotFound();

            var result = await _repository.GetById(Id, cancellationToken);

            if(result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(Person))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] PersonDto entity,CancellationToken cancellation)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var person = _mapper.Map<Person>(entity);

            var result = await _repository.Add(person,cancellation);

            return Ok(result);
        }

        [HttpPut("Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] PersonDto entity,int Key ,CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var entity_ = await GetById(Key, cancellationToken);
            if (entity_ == null)
                return BadRequest();


            var person = _mapper.Map<Person>(entity);
            person.Id = Key;

            var resualt = await _repository.Update(person, Key, cancellationToken);
            return Ok(resualt);

        }
    }
}

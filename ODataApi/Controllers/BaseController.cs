using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataApi.Dto;
using ODataApi.Models;
using ODataApi.Services;

namespace ODataApi.Controllers
{
    public class BaseController<T>:Controller where T : class 
    {
       private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;

        public BaseController(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var Entites = await _repository.GetAll().ToListAsync(cancellationToken) ;

            if (!Entites.Any())
                return NotFound();

            var result = _mapper.Map<List<T>>(Entites);
            return Ok(result);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ODataApi.Atttribute;
using ODataApi.Dto;
using ODataApi.Models;
using ODataApi.Services;

namespace ODataApi.Controllers
{
    [GenericControllerNameConvention]
    [Route("[controller]")]
    public class BaseController<TEntity,TRequset,TResponse>:Controller where TEntity : class where TRequset : class where TResponse : class
    {
       private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseController(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var Entites = await _repository.GetAll().ToListAsync(cancellationToken) ;

            if (!Entites.Any())
                return NotFound();

            var result = _mapper.Map<List<TEntity>>(Entites);
            return Ok(result);
        }
    }
}

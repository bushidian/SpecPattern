using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities = SpecPattern.Framework.Data.Entities;
using Dto = SpecPattern.DataContracts.Movie;
using SpecPattern.Services;

namespace SpecPattern.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMovieManagerService _movieManagerService;
        public ValuesController(IMapper mapper, IMovieManagerService movieManagerService)
        {
            _mapper = mapper;
            _movieManagerService = movieManagerService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var entity = new Entities.Movie();
            entity.ReleaseDate = DateTime.Now;
            var dto = _mapper.Map<Dto.Movie>(entity);
            var service = _movieManagerService;
        
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

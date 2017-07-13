using System;
using Microsoft.AspNetCore.Mvc;
using SpecPattern.Services;
using AutoMapper;
using Entities = SpecPattern.Framework.Data.Entities;
using Dto = SpecPattern.DataContracts.Movie;
using System.Collections.Generic;

namespace SpecPattern.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {

        #region Fileds

        private readonly IMapper _mapper;
        private readonly IMovieManagerService _movieManagerService;

        #endregion

        #region Constr

        public MovieController(IMapper mapper, IMovieManagerService movieManagerService)
        {
            _mapper = mapper;
            _movieManagerService = movieManagerService;
        }

        #endregion


        #region Method

        [HttpGet]
        public List<Dto.Movie> Get()
        {
            var entity = new Entities.Movie();
            entity.ReleaseDate = DateTime.Now;
            var dto = _mapper.Map<Dto.Movie>(entity);
            var service = _movieManagerService;
            return service.GetList(new Dto.MovieSearchCriteria(), 1, 10);
        }

        #endregion


    }
}

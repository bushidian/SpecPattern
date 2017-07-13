using System;
using System.Collections.Generic;
using AutoMapper;
using SpecPattern.Framework.Repository;
using Dto = SpecPattern.DataContracts.Movie;
using Entities = SpecPattern.Framework.Data.Entities;
using SpecPattern.Framework.Repository.Implment;
using System.Linq;
using SpecPattern.DataContracts.Movie;

namespace SpecPattern.Services.Implment
{
    public class MovieManagerService : IMovieManagerService
    {

        #region Fileds

        private IMapper _mapper;
        private IMovieRepository _movieRepository;

        #endregion

        #region Constr

        public MovieManagerService(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        #endregion

        #region Method


        public List<Dto.Movie> GetList(MovieSearchCriteria criteria, int page, int pageSize)
        {
            var criteriaEntity = new Framework.Model.Criteria.MovieSearchCriteria() { Name = criteria.Name };
            var result = _movieRepository.GetList(criteriaEntity, page, pageSize);
            var entity =  _mapper.Map<List<Entities.Movie>, List<Dto.Movie>>(result);
            return entity;
        }

        #endregion
    }
}

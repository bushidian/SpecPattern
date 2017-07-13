using AutoMapper;
using Entities = SpecPattern.Framework.Data.Entities;
using Dto = SpecPattern.DataContracts.Movie;
using SpecPattern.Framework.Model.Criteria;

namespace SpecPattern.DataContracts.Converters.Core
{
    // AutoMapper Doc Url https://github.com/AutoMapper/AutoMapper/wiki/Configuration#profile-instances
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Entities.Movie, Dto.Movie>();
            CreateMap<Dto.MovieSearchCriteria, MovieSearchCriteria>();
        }
    }
}

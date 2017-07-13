using System.Collections.Generic;
using SpecPattern.DataContracts.Movie;

namespace SpecPattern.Services
{
    public interface IMovieManagerService
    {

        List<Movie> GetList(MovieSearchCriteria criteria, int page, int pageSize);

    }
}

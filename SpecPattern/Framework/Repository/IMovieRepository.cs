using SpecPattern.Framework.Data.Entities;
using System.Collections.Generic;
using SpecPattern.Framework.Model.Criteria;

namespace SpecPattern.Framework.Repository
{
    public interface IMovieRepository: IRepository<Movie>
    {
         List<Movie> GetList(MovieSearchCriteria criteria, int page = 0, int pageSize = 10);
    }
}

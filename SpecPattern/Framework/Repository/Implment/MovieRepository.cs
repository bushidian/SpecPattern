using System.Collections.Generic;
using SpecPattern.Framework.Data;
using SpecPattern.Framework.Data.Entities;
using System.Linq;
using SpecPattern.Framework.Model.Criteria;
using SpecPattern.Framework.Specification;
using SpecPattern.Extensions;
using SpecPattern.Framework.Specification.Movie;

namespace SpecPattern.Framework.Repository.Implment
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(SpecDbContext context) : base(context)
        {

        }

        public List<Movie> GetList(MovieSearchCriteria criteria,  int page = 1, int pageSize = 10)
        {

            var specification = Specification<Movie>.All;
            
            if(criteria.Name.NotNullOrBlank())
            {
                specification = specification.And(new NameSpecification(criteria.Name));
            }

            return Table.Where(specification.ToExpression())
                .Skip((page -1) * pageSize)
                .Take(pageSize).ToList();
        }


    }

}

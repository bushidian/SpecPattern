using System;
using System.Linq.Expressions;
using Entities = SpecPattern.Framework.Data.Entities;

namespace SpecPattern.Framework.Specification.Movie
{
    public class NameSpecification : Specification<Entities.Movie>
    {

        private readonly string _name;

        public NameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Entities.Movie, bool>> ToExpression()
        {
            return o => o.Name == _name;
        }
    }
}

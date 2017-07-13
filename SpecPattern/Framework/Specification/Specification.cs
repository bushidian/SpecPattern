using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpecPattern.Framework.Specification
{

    internal sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }


    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new IdentitySpecification<T>();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And(Specification<T> specification)
        {
            if (this == All)
                return specification;
            if (specification == All)
                return this;

            return new AndSpecification(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            if (this == All || specification == All)
                return All;

            return new OrSpecification(this, specification);
        }

        public Specification<T> Not()
        {
            return new NotSpecification(this);
        }

        internal sealed class AndSpecification : Specification<T>
        {
            private readonly Specification<T> _left;
            private readonly Specification<T> _right;

            public AndSpecification(Specification<T> left, Specification<T> right)
            {
                _right = right;
                _left = left;
            }

            public override Expression<Func<T, bool>> ToExpression()
            {
                Expression<Func<T, bool>> leftExpression = _left.ToExpression();
                Expression<Func<T, bool>> rightExpression = _right.ToExpression();

                BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

                return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
            }
        }


        internal sealed class OrSpecification : Specification<T>
        {
            private readonly Specification<T> _left;
            private readonly Specification<T> _right;

            public OrSpecification(Specification<T> left, Specification<T> right)
            {
                _right = right;
                _left = left;
            }

            public override Expression<Func<T, bool>> ToExpression()
            {
                Expression<Func<T, bool>> leftExpression = _left.ToExpression();
                Expression<Func<T, bool>> rightExpression = _right.ToExpression();

                BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);

                return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters.Single());
            }
        }


        internal sealed class NotSpecification : Specification<T>
        {
            private readonly Specification<T> _specification;

            public NotSpecification(Specification<T> specification)
            {
                _specification = specification;
            }

            public override Expression<Func<T, bool>> ToExpression()
            {
                Expression<Func<T, bool>> expression = _specification.ToExpression();
                UnaryExpression notExpression = Expression.Not(expression.Body);

                return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
            }
        }
    }
}

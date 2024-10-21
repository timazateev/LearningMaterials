using System.Linq.Expressions;

namespace LearningMaterials.Patterns.RepositoryAndSpecification
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(object candidate);
        ISpecification And(ISpecification other);
        ISpecification AndNot(ISpecification other);
        ISpecification Or(ISpecification other);
        ISpecification OrNot(ISpecification other);
        ISpecification Not();
    }

    public abstract class CompositeSpecification : ISpecification
    {
        public abstract bool IsSatisfiedBy(object candidate);

        public ISpecification And(ISpecification other)
        {
            return new AndSpecification(this, other);
        }

        public ISpecification AndNot(ISpecification other)
        {
            return new AndNotSpecification(this, other);
        }

        public ISpecification Or(ISpecification other)
        {
            return new OrSpecification(this, other);
        }

        public ISpecification OrNot(ISpecification other)
        {
            return new OrNotSpecification(this, other);
        }

        public ISpecification Not()
        {
            return new NotSpecification(this);
        }
    }

    public class AndSpecification : CompositeSpecification
    {
        private readonly ISpecification _leftCondition;
        private readonly ISpecification _rightCondition;

        public AndSpecification(ISpecification left, ISpecification right)
        {
            _leftCondition = left;
            _rightCondition = right;
        }

        public override bool IsSatisfiedBy(object candidate)
        {
            return _leftCondition.IsSatisfiedBy(candidate) && _rightCondition.IsSatisfiedBy(candidate);
        }
    }

    public class AndNotSpecification : CompositeSpecification
    {
        private readonly ISpecification _leftCondition;
        private readonly ISpecification _rightCondition;

        public AndNotSpecification(ISpecification left, ISpecification right)
        {
            _leftCondition = left;
            _rightCondition = right;
        }

        public override bool IsSatisfiedBy(object candidate)
        {
            return _leftCondition.IsSatisfiedBy(candidate) && _rightCondition.IsSatisfiedBy(candidate) != true;
        }
    }

    public class OrSpecification : CompositeSpecification
    {
        private readonly ISpecification _leftCondition;
        private readonly ISpecification _rightCondition;

        public OrSpecification(ISpecification left, ISpecification right)
        {
            _leftCondition = left;
            _rightCondition = right;
        }

        public override bool IsSatisfiedBy(object candidate)
        {
            return _leftCondition.IsSatisfiedBy(candidate) || _rightCondition.IsSatisfiedBy(candidate);
        }
    }

    public class OrNotSpecification : CompositeSpecification
    {
        private readonly ISpecification _leftCondition;
        private readonly ISpecification _rightCondition;

        public OrNotSpecification(ISpecification left, ISpecification right)
        {
            _leftCondition = left;
            _rightCondition = right;
        }

        public override bool IsSatisfiedBy(object candidate)
        {
            return _leftCondition.IsSatisfiedBy(candidate) || _rightCondition.IsSatisfiedBy(candidate) != true;
        }
    }

    public class NotSpecification : CompositeSpecification
    {
        private readonly ISpecification _wrapped;

        public NotSpecification(ISpecification x)
        {
            _wrapped = x;
        }

        public override bool IsSatisfiedBy(object candidate)
        {
            return !_wrapped.IsSatisfiedBy(candidate);
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
        ISpecification<T> And(ISpecification<T> other);
        ISpecification<T> AndNot(ISpecification<T> other);
        ISpecification<T> Or(ISpecification<T> other);
        ISpecification<T> OrNot(ISpecification<T> other);
        ISpecification<T> Not();
    }

    public abstract class LinqSpecification<T> : CompositeSpecification<T>
    {
        public abstract Expression<Func<T, bool>> AsExpression();
        public override bool IsSatisfiedBy(T candidate) => AsExpression().Compile()(candidate);
    }

    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);
        public ISpecification<T> And(ISpecification<T> other) => new AndSpecification<T>(this, other);
        public ISpecification<T> AndNot(ISpecification<T> other) => new AndNotSpecification<T>(this, other);
        public ISpecification<T> Or(ISpecification<T> other) => new OrSpecification<T>(this, other);
        public ISpecification<T> OrNot(ISpecification<T> other) => new OrNotSpecification<T>(this, other);
        public ISpecification<T> Not() => new NotSpecification<T>(this);
    }

    public class AndSpecification<T> : CompositeSpecification<T>
    {
        readonly ISpecification<T> _left;
        readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T candidate) => _left.IsSatisfiedBy(candidate) && _right.IsSatisfiedBy(candidate);
    }

    public class AndNotSpecification<T> : CompositeSpecification<T>
    {
        readonly ISpecification<T> _left;
        readonly ISpecification<T> _right;

        public AndNotSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T candidate) => _left.IsSatisfiedBy(candidate) && !_right.IsSatisfiedBy(candidate);
    }

    public class OrSpecification<T> : CompositeSpecification<T>
    {
        readonly ISpecification<T> _left;
        readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T candidate) => _left.IsSatisfiedBy(candidate) || _right.IsSatisfiedBy(candidate);
    }
    public class OrNotSpecification<T> : CompositeSpecification<T>
    {
        readonly ISpecification<T> _left;
        readonly ISpecification<T> _right;

        public OrNotSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T candidate) => _left.IsSatisfiedBy(candidate) || !_right.IsSatisfiedBy(candidate);
    }

    public class NotSpecification<T> : CompositeSpecification<T>
    {
        readonly ISpecification<T> _other;
        public NotSpecification(ISpecification<T> other) => _other = other;
        public override bool IsSatisfiedBy(T candidate) => !_other.IsSatisfiedBy(candidate);
    }
}

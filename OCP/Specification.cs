using System;

namespace OCP
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product p)
        {
            return p.Size == size;
        }
    }

    public class ColourSpecification : ISpecification<Product>
    {
        private readonly Colour colour;
        public ColourSpecification(Colour colour)
        {
            this.colour = colour;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Colour == colour;
        }
    }

    public class AndSpecification : ISpecification<Product>
    {
        private readonly ISpecification<Product> firstSpec, secondSpec;

        public AndSpecification(ISpecification<Product> firstSpec,
            ISpecification<Product> secondSpec)
        {
            this.firstSpec = firstSpec ?? throw new ArgumentNullException(paramName: nameof(firstSpec));
            this.secondSpec = secondSpec ?? throw new ArgumentNullException(paramName: nameof(secondSpec)) ;
        }
        public bool IsSatisfied(Product t)
        {
            return firstSpec.IsSatisfied(t) && secondSpec.IsSatisfied(t);
        }
    }
}
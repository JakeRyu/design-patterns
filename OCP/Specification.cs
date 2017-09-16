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
}
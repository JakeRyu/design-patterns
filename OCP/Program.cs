using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace OCP
{
    public enum Colour
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large
    }

    public class Product
    {
        public string Name;
        public Colour Colour;
        public Size Size;

        public Product(string name, Colour colour, Size size)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
            Colour = colour;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            // foreach(var product in products)
            // {
            //     if(product.Size == size)
            //         yield return product;
            // }

            return products.Where(p => p.Size == size).AsEnumerable();
        }

        public IEnumerable<Product> FilterByColour(IEnumerable<Product> products, Colour colour)
        {
            return products.Where(p => p.Colour == colour);
        }

        public IEnumerable<Product> FilterByColourAndSize(IEnumerable<Product> products, Colour colour, Size size)
        {
            return products.Where(p => p.Colour == colour && p.Size == size);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Colour.Green, Size.Small);
            var tree = new Product("Tree", Colour.Green, Size.Large);
            var house = new Product("House", Colour.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            WriteLine("Large products: ");

            var pf = new ProductFilter();
            foreach(var p in pf.FilterBySize(products, Size.Large))
            {
                WriteLine($" - {p.Name} is large");
            }

            foreach(var p in pf.FilterByColour(products, Colour.Green))
            {
                WriteLine($" - {p.Name} is green");
            }

            foreach(var p in pf.FilterByColourAndSize(products, Colour.Green, Size.Large))
            {
                WriteLine($" - {p.Name} is green and large");
            }
                
        }
    }
}

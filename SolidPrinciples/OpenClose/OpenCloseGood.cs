using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OpenClose.Good
{
    internal class OpenCloseGood
    {
        internal enum Color
        {
            Red, Green, Blue
        }

        internal enum Size
        {
            Small, Medium, Large
        }

        internal class Product
        {
            public string Name { get; set; }

            public Color Color { get; set; }

            public Size Size { get; set; }

            public Product(string name, Color color, Size size)
            {
                if (name == null)
                {
                    throw new ArgumentNullException(paramName: nameof(name));
                }

                Name = name;
                Color = color;
                Size = size;
            }
        }

        internal interface ISpecification<T>
        {
            bool IsSatisfied(T t);
        }

        internal interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }

        internal class ColorSpecification : ISpecification<Product>
        {
            private readonly Color _color;

            public ColorSpecification(Color color)
            {
                _color = color;
            }

            public bool IsSatisfied(Product product)
            {
                return product.Color == _color;
            }
        }

        internal class SizeSpecification : ISpecification<Product>
        {
            private readonly Size _size;

            public SizeSpecification(Size size)
            {
                _size = size;
            }

            public bool IsSatisfied(Product product)
            {
                return product.Size == _size;
            }
        }

        internal class AndSpecification<T> : ISpecification<T>
        {
            private readonly ISpecification<T> _first, _second;

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                _first = first ?? throw new ArgumentNullException(paramName: nameof(first));
                _second = second ?? throw new ArgumentNullException(paramName: nameof(second));
            }

            public bool IsSatisfied(T t)
            {
                return _first.IsSatisfied(t) && _second.IsSatisfied(t);
            }
        }

        internal class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var i in items)
                {
                    if (spec.IsSatisfied(i))
                    {
                        yield return i;
                    }
                }
            }
        }

        public static void Demo()
        {
            var apple = new Product("Apple", Color.Red, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var bf = new BetterFilter();

            Console.WriteLine("Green products (new):");

            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} is green");
            }

            Console.WriteLine("Large blue items (new):");

            foreach (var p in bf.Filter(
                products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecification(Size.Large))))
            {
                Console.WriteLine($" - {p.Name} is big and blue");
            }
        }
    }
}

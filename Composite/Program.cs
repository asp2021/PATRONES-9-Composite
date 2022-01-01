using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    class Program
    {
        public abstract class Product
        {
            protected Product(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; private set; }
            public decimal Price { get; private set; }

            public abstract void Add(Product product);
            public abstract void Remove(Product product);

            public abstract string GetPrice();
        }

        public class SimpleProduct : Product
        {
            public SimpleProduct(string name, decimal price) : base(name, price)
            {
            }

            public override void Add(Product product)
            {
                // Operacion no se puede realizar porque es el elemento que se encuentra mas abajo de la jerarquia,.
            }

            public override void Remove(Product product)
            {
                // Operacion no se puede realizar porque es el elemento que se encuentra mas abajo de la jerarquia,.
            }

            public override string GetPrice()
            {
                return $"El precio de {Name} es {Price.ToString("N2")}";
            }
        }

        public class CompositeProduct : Product
        {
            List<Product> _products = new List<Product>();

            public CompositeProduct(string name): base(name, 0)
            {

            }

            public override void Add(Product product)
            {
                _products.Add(product);
            }

            public override void Remove(Product product)
            {
                _products.Remove(product);
            }


            public override string GetPrice()
            {
                return $"El precio de {Name} es {_products.Sum(p => p.Price).ToString("N2")}";
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("COMPOSITE" + '\n');
            Console.WriteLine("Permite tratar una serie de objetos los cuales pertenecen a una Jerarquia de una forma similar." + '\n');

            Product ram = new SimpleProduct("Ram 16gb", 7000);
            Product processor = new SimpleProduct("Intel I7", 17000);
            Product videoCard = new SimpleProduct("nVidia GTX 5600", 172000);
            Product keyboard = new SimpleProduct("Teclado Genius", 1000);
            Product mouse = new SimpleProduct("Mouse Genius", 800);
            Product harddisk = new SimpleProduct("Disco solido 1TB", 12000);
            Product slimcase= new SimpleProduct("Gabinete slim", 12000);
            Product led = new SimpleProduct("Monitor Led 22", 22000);

            Product gameKit = new CompositeProduct("Computador gamer");
            gameKit.Add(ram);
            gameKit.Add(processor);
            gameKit.Add(videoCard);
            gameKit.Add(keyboard);
            gameKit.Add(mouse);
            gameKit.Add(harddisk);
            gameKit.Add(slimcase);
            gameKit.Add(led);

            Console.WriteLine(gameKit.GetPrice());
            Console.ReadLine();
        }
    }
}

using System;

namespace task5
{
    class Shop
    {
        private string worker;
        public string product;
        public string doc;
        public int qty;
        private double price;

        public Shop()
        {
            Console.Write("Введите имя работника: ");
            worker = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите название продукта: ");
            product = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите название документа: ");
            doc = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите количество продуктов: ");
            qty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите цену продукта: ");
            price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }

        public Shop(string worker, string product, string doc, int qty, double price)
        {
            this.worker = worker;
            this.product = product;
            this.doc = doc;
            this.qty = qty;
            this.price = price;
        }

        public void Show()
        {
            Console.WriteLine("Name worker: " + worker + " name product: " + product + " name document: " + doc +
                " quantity products: " + qty.ToString() + " Price product: " + price.ToString());
        }

        public static Shop operator +(Shop s1, Shop s2)
        {
           
            return new Shop(s1.worker + " " + s2.worker, s1.product + " " + s2.product, s1.doc + " " + s2.doc, s1.qty + s2.qty, s1.price + s2.price);
           
        }

        public static bool operator >(Shop s1, Shop s2)
        {
            return s1.price > s2.price;
        }

        public static bool operator <(Shop s1, Shop s2)
        {
            return s1.price < s2.price;
        }

        ~Shop() { }
    }



    class Program
    {
        
        static void Main(string[] args)
        {
            Shop shop1 = new Shop();
            shop1.Show();
            Console.WriteLine();
            Shop shop2 = new Shop("Jhon", "cake", "ГОСТ345", 25, 15.45);
            shop2.Show();
            Console.WriteLine();
            Shop shop3 = new Shop();
            shop3.Show();
            Console.WriteLine();
            Shop shop4 =shop1 + shop2;
            shop4.Show();
            Console.WriteLine();
            Console.WriteLine(shop1 > shop2);
        }
    }
}

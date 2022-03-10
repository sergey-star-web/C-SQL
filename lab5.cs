/*
Задание
В соответствии с вариантом задания самостоятельно разработать класс и консольную программу, иллюстрирующую его возможности. 
Требования к классу:
•	часть полей должны быть закрытыми (private), часть - открытыми (public); 
•	класс должен иметь по крайней мере 2 конструктора: конструктор по умолчанию и конструктор c параметрами;  
•	необходимо задать набор свойств для получения значений и модификации закрытых полей данных;  
•	для разработанного класса должна быть перегружены 2 операции: арифметическая и сравнения. Выбор перегружаемых операций определяется семантикой предметной области.
Пример для класса «Деталь»:
Поля:
•	код;
•	размеры;
•	кто изготовил;
•	дата изготовления.
Действия над объектами класса:
•	вывод данных о детали;
•	операции сравнения объектов;
•	присваивание.
Для остальных вариантов сделать по аналогии.  
В программе помимо исходного кода класса должен быть исходный код, демонстрирующий работу класса:
1.	Создание не менее 3 экземпляров класса с использованием конструкторов с параметрами.
2.	Демонстрация работы перегруженных операций.
3.	Демонстрация работы свойств при получении значений и модификации полей данных, находящихся в закрытой части класса.
22	магазин
*/
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

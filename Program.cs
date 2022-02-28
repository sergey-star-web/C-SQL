using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        struct train{
            private int number;
            private string direction;
            private DateTime datetime_departure;
            private DateTime datetime_arrival;
            public train(int number, string direction, DateTime datetime_departure, DateTime datetime_arrival)
            {
                this.number = number;
                this.direction = direction;
                this.datetime_departure = datetime_departure;
                this.datetime_arrival = datetime_arrival;
            }

            public void show()
            {
                Console.WriteLine("Номер поезда: " + number.ToString() + " направление: " + direction.ToString() + 
                    " дата отправления: "+datetime_departure.ToString()+" дата прибытия: "+datetime_arrival.ToString());
                Console.WriteLine((datetime_arrival.Subtract(datetime_departure)).Days);
            }

            public void ShowMore24h()
            {
                if ((datetime_arrival.Subtract(datetime_departure)).Days>=1)
                {
                    Console.WriteLine("Номер поезда: " + number.ToString() + " направление: " + direction.ToString() +
                    " дата отправления: " + datetime_departure.ToString() + " дата прибытия: " + datetime_arrival.ToString());
                }
            }
        }

        static void Main(string[] args)
        {

        int number=0, quant=0;
        string direction=" ", str;
        DateTime datetime_departure;
        DateTime datetime_arrival;
        List<train> trains =  new List<train>();
            m:
            Console.WriteLine("Введите кол-во поездов которых хотите ввести: ");
            str = Console.ReadLine();
            if (int.TryParse(str, out int num))
            {
                quant = Convert.ToInt32(str);
            }
            else
            {
                Console.WriteLine("Неверный тип данных");
                goto m;
            }

            for (int i=0; i<quant; i++)
            {
                m1:
                Console.WriteLine("Введите номер поезда: ");
                str = Console.ReadLine();
                if (int.TryParse(str, out int num1))
                {
                    number = Convert.ToInt32(str);
                }
                else
                {
                    Console.WriteLine("Неверный тип данных");
                    goto m1;
                }

                Console.WriteLine("Введите направление: ");
                direction = Console.ReadLine();

                m2:
                Console.WriteLine("Введите дату и время отправления: ");
                str = Console.ReadLine();
                if (DateTime.TryParse(str, out DateTime num2))
                {
                    datetime_departure = Convert.ToDateTime(str);
                }
                else
                {
                    Console.WriteLine("Неверный тип данных");
                    goto m2;
                }

            m3:
                Console.WriteLine("Введите дату и время прибытия: ");
                str = Console.ReadLine();
                if (DateTime.TryParse(str, out DateTime num3))
                {
                    datetime_arrival = Convert.ToDateTime(str);
                    if (datetime_arrival <= datetime_departure)
                    {
                        Console.WriteLine("Время прибытия должно быть больше времения отправления");
                        goto m3;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный тип данных");
                    goto m2;
                }

                train tr = new train(number, direction, datetime_departure, datetime_arrival);
                trains.Add(tr);
            }
            Console.WriteLine();
            Console.WriteLine("Вывод всех поездов:");
            foreach (train train in trains)
            {
                train.show();
            }
            Console.WriteLine();
            Console.WriteLine("Вывод поездов пребывающих в пути более суток:");
            foreach (train train in trains)
            {
                train.ShowMore24h();
            }
        }
    }
}

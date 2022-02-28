//2.	Создать консольное приложение на языке C# в соответствии со следующими требованиями:
//•	размеры прямоугольной матрицы задаются через параметры командной строки (кол-во и тип переданных параметров должны проверяться программой);
//•	в методе main должен быть реализован вызов созданных функций;
//•	матрица заполняется положительными и отрицательными случайными числами с помощью метода, возвращающего массив (целые числа – не более 2 разрядов, вещественные – не более 2 разрядов до десятичной точки и 1 разряда после десятичной точки);
//•	вывод на консоль массивов реализовать с помощью одноименных методов, в качестве параметра которым передается либо одномерный, либо двумерный массив;
//•	решение задачи реализовать с помощью метода, имеющего тип void. Данные возращать через параметр с модификатором ref или out.
//22	вещественный	Получить вектор как строку матрицы, в которой находится максимальный элемент матрицы.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {

        static void SetArray(ref double[] array1, ref double[,] array2, ref int type_matrix)
        {
            Random rnd = new Random();
            if (type_matrix == 1)
            {
                int num = rnd.Next(1, 3);
                for (int i = 0; i < array1.Length; i++)
                {
                    double value = (20 * rnd.NextDouble() - 10);
                    if (num==1)
                    {
                        array1[i] = value; 
                    }
                    else
                    {
                        array1[i] = Math.Round(value, 1);
                    }
                }
            }

            else if (type_matrix == 2)
            {
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    for (int j = 0; j < array2.GetLength(1); j++)
                    {
                        double value = (20 * rnd.NextDouble() - 10);
                        if (i < 3)
                        {
                            if ((i+1) % 2 == 0)
                            {
                                array2[i, j] = value;
                            }
                            else
                            {
                                array2[i, j] = Math.Round(value,1);
                            }
                        }
                        else
                            array2[i, j] = Math.Round(value, 3);
                    }
                }
            }
        }

        static void ShowArray(ref double[] array1, ref double[,] array2, ref int type_matrix)
        {
            if (type_matrix == 1)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    Console.Write(array1[i].ToString()+" ");
                }
            }

            else if (type_matrix == 2)
            {
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    for (int j = 0; j < array2.GetLength(1); j++)
                    {
                        Console.Write(array2[i,j].ToString() + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void FindMaxElem(ref double[] array1, ref double[,] array2, ref int type_matrix)
        {
            double max_elem = 0;
            if (type_matrix == 1)
            {
                max_elem = array1[0];
                for (int i = 0; i < array1.Length; i++)
                {
                    if (max_elem < array1[i])
                    {
                        max_elem = array1[i];
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Строка в которой имеется максимальный элемент:");
                for (int i = 0; i < array1.Length; i++)
                {
                    Console.Write(array1[i].ToString() + " ");
                }
            }

            else if (type_matrix == 2)
            {
                max_elem = array2[0,0];
                int num_row = 0;
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    for (int j = 0; j < array2.GetLength(1); j++)
                    {
                        if (max_elem < array2[i,j])
                        {
                            max_elem = array2[i,j];
                            num_row = i;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Строка в которой имеется максимальный элемент:");
                for (int j = 0; j < array2.GetLength(1); j++)
               {
                        Console.Write(array2[num_row, j].ToString() + " ");
               }
            }
            Console.WriteLine();
            Console.WriteLine("Максимальный элемент: " + max_elem.ToString());
        }

        static void Main(string[] args)
        {
            int r, c;
           
                if (args.Length > 1)
                {
                  if ( (int.TryParse(args[0], out int j) && (int.TryParse(args[1], out int i) )))
                  {
                    string rows = args[0], cols = args[1];
                    r = Convert.ToInt32(rows);
                    c = Convert.ToInt32(cols);
                    double[,] array2 = new double[r, c];
                    double[] array1 = new double[0];
                    int type_matrix = 2;
                    SetArray(ref array1, ref array2, ref type_matrix);
                    ShowArray(ref array1, ref array2, ref type_matrix);
                    FindMaxElem(ref array1, ref array2, ref type_matrix);
                  }
                else
                {
                    Console.WriteLine("Неверный тип данных");
                }
                }

                else
                {
                   if (int.TryParse(args[0], out int j)){
                      string rows = args[0];
                      r = Convert.ToInt32(rows);
                      double[] array1 = new double[r];
                      double[,] array2 = new double[0, 0];
                      int type_matrix = 1;
                      SetArray(ref array1, ref array2, ref type_matrix);
                      ShowArray(ref array1, ref array2, ref type_matrix);
                      FindMaxElem(ref array1, ref array2, ref type_matrix);
                   }
                else
                {
                    Console.WriteLine("Неверный тип данных");
                }
                }
            
        }
    }
}

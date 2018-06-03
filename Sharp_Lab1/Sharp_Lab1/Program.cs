
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharp_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Введите размер матрицы (Количество нефтепроводов): ");
                N = Int32.Parse(Console.ReadLine());
            } while (N <= 1);

            Console.Write("Введите стоимость прокладки 1го километра нефтепровода: ");
            int workValueForNeft = Int32.Parse(Console.ReadLine());

            int[,] matrix = new int[N, N];
            int randOrByHand;
            do
            {
                Console.Write("Генерация матрицы случайными числами или ручной ввод? (1,2)");
                randOrByHand = Int32.Parse(Console.ReadLine());
            } while (randOrByHand < 1 || randOrByHand > 2);

            if (randOrByHand == 1)
            {
                matrix = createRandMatr(N);
            }
            else
            {
                matrix = inputByHandMatrix(N);
            }


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.Write("\n");
            }
            algoritmPrima(matrix, N, workValueForNeft);
            Console.ReadLine();
        }

        static int[,] createRandMatr(int neftCount)
        {

            int[,] matrics = new int[neftCount, neftCount];
            Random rnd = new Random();
            for (int i = 0; i < neftCount; i++)
            {
                for (int j = i + 1; j < neftCount; j++)
                {

                    matrics[i, j] = rnd.Next(1, 10);
                    matrics[j, i] = matrics[i, j];

                }
            }
            return matrics;
        }
        static int[,] inputByHandMatrix(int N)
        {
            int[,] matrix = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {

                    Console.WriteLine("Введите елемент [" + i + "," + j + "] : ");
                    matrix[i, j] = Convert.ToInt16(Console.ReadLine());
                    matrix[j, i] = matrix[i, j];

                }
            }
            return matrix;
        }

        static void algoritmPrima(int[,] matrix, int size, int workValueForNeft)
        {
            int sumWorkValueForNeft = 0;
            bool[,] tf = new bool[size, size];
            const int start = 0;
            int bird = 0;
            int[] tempIndexMinMass = new int[2] { int.MaxValue, 0 };
            List<int> way = new List<int>();
            way.Add(start);

            //findMin(matrix, start, size, way);

            while (bird != size - 1)
            {
                foreach (int count in way)
                {

                    if (findMin(matrix, count, size, way)[0] < tempIndexMinMass[0])
                    {
                        tempIndexMinMass = findMin(matrix, count, size, way);
                    }

                }
                way.Add(tempIndexMinMass[1]);
                foreach (int count in way)
                { Console.Write("\n" + count + " "); }
                Console.Write("\nMin value for " + tempIndexMinMass[1] + " is " + tempIndexMinMass[0] + "\n");
                sumWorkValueForNeft += tempIndexMinMass[0];
                tempIndexMinMass[0] = int.MaxValue; tempIndexMinMass[1] = 0;
                bird++;

            }
            Console.Write("\nСумарные затраты на прокладку нефтепроводов: " + sumWorkValueForNeft * workValueForNeft);
        }

        static int[] findMin(int[,] matrix, int start, int size, List<int> way)
        {
            int min = 10;
            int minIndex = 0;
            bool flag = true;
            for (int i = 0; i < size; i++)
            {
                foreach (int bird in way)
                {
                    if (i == bird)
                    {
                        flag = false;
                        break;
                    }
                    else { flag = true; }
                }
                if (flag == false) { continue; }

                if (matrix[start, i] < min)
                {
                    min = matrix[start, i];
                    minIndex = i;
                }
            }
            int[] someArray = new int[2]; someArray[0] = min; someArray[1] = minIndex;
            return someArray;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            int[] numberOfRepetitions = new int[] { 2, 1, 1, 3, 4, 4, 7, 2, 3 };
            int[] arrayOfNumbers = new int[numberOfRepetitions.Sum()];

            double[] Mx = new double[arrayOfNumbers.Length];

            int j = 0;
            int a = 0;
            int moda;
            int mediana;
            int average;
            int indexMode;
            int currentNumber;
            int rangeOfVariation;
            int currentRepetition;

            double dispersion;
            double coeffOfVariation;
            double standartDeviation;

            // заполняем массив
            while (j < arrayOfNumbers.Length)
            {
                currentNumber = numbers[a];
                currentRepetition = numberOfRepetitions[a];

                for (int i = 0; i < currentRepetition; i++)
                {
                    arrayOfNumbers[j] = currentNumber;
                    j++;

                }

                a++;
            }

            Console.WriteLine("----------------------------+-------------------");

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                Console.Write(arrayOfNumbers[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------+-------------------");

            //средне ариф
            average = arrayOfNumbers.Sum() / arrayOfNumbers.Length;

            Console.WriteLine("Средне-арифметическое число | " + average);
            Console.WriteLine("----------------------------+-------------------");

            //мода
            indexMode = Array.IndexOf(numberOfRepetitions, numberOfRepetitions.Max());
            moda = numbers[indexMode];

            Console.WriteLine("Мода                        | " + moda);
            Console.WriteLine("----------------------------+-------------------");

            //медиана
            mediana = CalcMediana(arrayOfNumbers);

            Console.WriteLine("Медиана                     | " + mediana);
            Console.WriteLine("----------------------------+-------------------");

            //размах вариации
            rangeOfVariation = arrayOfNumbers.Max() - arrayOfNumbers.Min();

            Console.WriteLine("Размах вариации             | " + rangeOfVariation);
            Console.WriteLine("----------------------------+-------------------");

            //Дисперсия
            for (int i = 0; i < Mx.Length; i++)
            {
                Mx[i] = Math.Pow((arrayOfNumbers[i] - average), 2);
            }

            dispersion = Mx.Sum() / (arrayOfNumbers.Length - 1);
            Console.WriteLine("Дисперсия                   | " + dispersion);
            Console.WriteLine("----------------------------+-------------------");

            // стандартное отклонение
            standartDeviation = Math.Sqrt(dispersion);
            Console.WriteLine("Стандартное отклонение      | " + standartDeviation);
            Console.WriteLine("----------------------------+-------------------");

            // коэффициент вариации
            coeffOfVariation = (standartDeviation / average) * 100;
            Console.WriteLine("Коэффициент вариации        | " + coeffOfVariation);
            Console.WriteLine("----------------------------+-------------------");

            CalcAsymmetryFactor(standartDeviation, dispersion);
            KurtosisFactor(standartDeviation, dispersion);  

            Console.ReadKey();
        }

        private static int CalcMediana(int[] array)
        {
            //считаем общую сумму
            int sum = array.Sum();
            //перебираем элементы, пока не достигнем 50% от суммы:
            int accum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                accum += array[i];

                if (accum > sum / 2)
                    return i;
            }

            return array.Length;
        }

        private static void CalcAsymmetryFactor(double standartDeviation, double dispersion)
        {
            double asymmetryFactor = dispersion / Math.Pow(standartDeviation, 3);

            Console.WriteLine("Коэффициент ассиметрии      | " + Math.Round(asymmetryFactor, 2));

            if (asymmetryFactor > 0)
            {
                Console.WriteLine("Распределение выборки скошено влево");
                Console.WriteLine("----------------------------+-------------------");
            }
            else if (asymmetryFactor == 0)
            {
                Console.WriteLine("Распределение выборки симметричное");
                Console.WriteLine("----------------------------+-------------------");
            }
            else
            {
                Console.WriteLine("Распределение выборки скошено вправо");
                Console.WriteLine("----------------------------+-------------------");
            }
        }

        private static void KurtosisFactor(double standartDeviation, double dispersion)
        {
            double Ex = (dispersion / Math.Pow(standartDeviation, 4)) - 3;

            Console.WriteLine("Коэффициент эксцесса        | " + Math.Round(Ex, 2));

            if (Ex > 0)
            {
                Console.WriteLine("Эмпирическое распределение выборки острое");
                Console.WriteLine("----------------------------+-------------------");
            }
            else if (Ex == 0)
            {
                Console.WriteLine("Эмпирическое распределение выборки непонятно");
                Console.WriteLine("----------------------------+-------------------");
            }
            else
            {
                Console.WriteLine("Эмпирическое распределение выборки плоское");
                Console.WriteLine("----------------------------+-------------------");
            }
        }
    }
}
    


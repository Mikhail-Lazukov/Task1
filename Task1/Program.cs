using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {

        // Вывод значения матрицы на экран
        static void DisplayMatrix(int[,] matrix, int n, int m, int len = 0)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (len == 0)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    else
                    {
                        string output = "{0, " + len + "} ";
                        Console.Write(output, matrix[i, j]);
                    }
                }
                Console.Write('\n');
            }
        }

        // Поиск суммы всех четных и всех не четный чисел
        static (int even, int odd) SumEvenAndOdd(int[,] matrix)
        {
            int sumEven = 0;
            int sumOdd = 0;
            foreach ( var num in matrix)
            {
                if (num % 2 == 0)
                {
                    sumEven += num;
                }
                else
                {
                    sumOdd += num;
                }
            }          
            return (sumEven, sumOdd);
        }

        static void Main(string[] args)
        {
            try
            {
                // Размерность матрицы (строки,столбцы)
                int n, m;
                int[,] matrix;
                // Максимальное количесво цифр в числе 
                int len;

                Random random = new Random(DateTime.Now.Millisecond);
                Console.WriteLine("Введите число строк матрицы:");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите число столбцов матрицы:");
                m = Convert.ToInt32(Console.ReadLine());

                matrix = new int [n, m];
                len = (int)Math.Log10(n * m) + 1;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = random.Next(0, n * m - 1);
                    }
                }

                Console.WriteLine("Сгенерированная матрица:");
                DisplayMatrix(matrix, n, m, len);

                var evenAndOdd = SumEvenAndOdd(matrix);
                Console.WriteLine("Сумма всех четных чисел : {0} \n" +
                    "Сумма всех нечетных чисел : {1}" , evenAndOdd.even, evenAndOdd.odd);

            }
            catch
            {
                Console.WriteLine("Проверьте правильность введенных данных");
            }

            Console.ReadLine();
        }
    }
}

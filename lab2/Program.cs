using System;

namespace ЛР2
{
    class Program
    {
        static void Main(string[] args)
        {
            //змінна типу Matrix
            Matrix matrix = new Matrix();

            //вводимо кількість рядків і стовпців
            Console.WriteLine("Введiть кiлькiсть рядкiв першої матрицi");
            matrix.Rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпцiв першої матрицi");
            matrix.Columns = int.Parse(Console.ReadLine());
            
            //преевірка даних
            if (matrix.Rows == 0 || matrix.Columns == 0)
            {
                Console.WriteLine("Ви ввели невiрнi данi!");
                Environment.Exit(0);
            }

            //заповнюємо першу матрицю
            int[,] firstMatrix = new int[matrix.Rows, matrix.Columns];
            matrix.Values(firstMatrix);

            //виводимо
            Console.WriteLine("Перша матриця:");
            for (int i = 0; i < firstMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < firstMatrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(firstMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //вводимо кількість рядків і стовпців
            Console.WriteLine("Введiть кiлькiсть рядкiв другої матрицi");
            matrix.Rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпцiв другої матрицi");
            matrix.Columns = int.Parse(Console.ReadLine());
            if (matrix.Rows == 0 || matrix.Columns == 0)
            {
                Console.WriteLine("Ви ввели невiрнi данi!");
                Environment.Exit(0);
            }

            //заповнюємо другу матрицю
            int[,] secondMatrix = new int[matrix.Rows, matrix.Columns];
            matrix.Values(secondMatrix);

            //виводимо
            Console.WriteLine("Друга матриця:");
            for (int i = 0; i < secondMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < secondMatrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(secondMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //викликаємо методи, які вказані в завданні
            matrix.Suma(firstMatrix, secondMatrix);
            Console.WriteLine();

            matrix.Subtraction(firstMatrix, secondMatrix);
            Console.WriteLine();

            matrix.Multiplication(firstMatrix, secondMatrix);
            Console.WriteLine();

            Console.WriteLine("Введiть число, на яке буде помножена перша матриця:");
            int number = int.Parse(Console.ReadLine());
            matrix.MnozhenyaNaSkalyar(firstMatrix, number);
            Console.WriteLine();

            Console.WriteLine("Введiть число, на яке буде помножена друга матриця:");
            number = int.Parse(Console.ReadLine());
            matrix.MnozhenyaNaSkalyar(secondMatrix, number);
            Console.WriteLine();

            Console.WriteLine("Транспонування першої матрицi");
            Console.ReadKey();
            matrix.Transponuvanya(firstMatrix);
            Console.WriteLine();
            Console.WriteLine("Транспонування другої матрицi");
            matrix.Transponuvanya(secondMatrix);
            Console.WriteLine();

            matrix.IsEqual(firstMatrix, secondMatrix);
            Console.WriteLine();

            //створюємо булеву змінну, в яку присвоюємо значення відносно того, чи є матриця квадратною
            bool isSquare = matrix.IsSquare(firstMatrix);
            if (isSquare == true)
            {
                Console.WriteLine("Перша матриця є квадратною");
            }
            else
            {
                Console.WriteLine("Перша матриця не є квадратною");
            }

            isSquare = matrix.IsSquare(secondMatrix);
            if (isSquare == true)
            {
                Console.WriteLine("Друга матриця є квадратною");
            }
            else
            {
                Console.WriteLine("Друга матриця не є квадратною");
            }
            Console.WriteLine();

            Console.WriteLine("Перевiрка симетричностi першої матрицi");
            Console.ReadKey();
            matrix.PerevirkaSumetruchnosti(firstMatrix);
            Console.WriteLine();
            Console.WriteLine("Перевiрка симетричностi другої матрицi");
            matrix.PerevirkaSumetruchnosti(secondMatrix);
            Console.WriteLine();
            matrix.JsonSer(matrix);
            Console.WriteLine();
            matrix.JsonDes();
        }
    }
}

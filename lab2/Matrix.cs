using System;
using System.IO;
using System.Text.Json;

namespace ЛР2
{
    class Matrix
    {
        //поля класу
        private int _rows;
        public int Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }

        //поля класу
        private int _columns;
        public int Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
            }
        }

        //метод який заповнює значення матриці рандомними числами
        public int[,] Values(int[,] matrix)
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    matrix[i, j] = rnd.Next(1, 5); //заповнення рандомними числами
                }
            }

            return matrix;
        }

        //метод суми двох матриць
        public void Suma(int[,] firstMatrix, int[,] secondMatrix)
        {
            //перевірка чи можливе додавання матриць
            if (firstMatrix.GetUpperBound(0) != secondMatrix.GetUpperBound(0)
                || firstMatrix.GetUpperBound(1) != secondMatrix.GetUpperBound(1))
            {
                Console.WriteLine("Додавання неможливе! Розмiри матриць повиннi бути однаковими");
            }
            else
            {
                //нова матриця суми двох
                int[,] sumaMatrix = new int[firstMatrix.GetUpperBound(0) + 1, firstMatrix.GetUpperBound(1) + 1];
                for (int i = 0; i < firstMatrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < firstMatrix.GetUpperBound(1) + 1; j++)
                    {
                        sumaMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j]; //заповнюємо матрицю
                    }
                }

                //виводимо
                Console.WriteLine("Сума двох матриць дорiвнює:");
                for (int i = 0; i < sumaMatrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < sumaMatrix.GetUpperBound(1) + 1; j++)
                    {
                        Console.Write(sumaMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        //метод різниці двох матриць
        public void Subtraction(int[,] firstMatrix, int[,] secondMatrix)
        {
            //перевірка чи можлива різниця матриць
            if (firstMatrix.GetUpperBound(0) != secondMatrix.GetUpperBound(0)
                || firstMatrix.GetUpperBound(1) != secondMatrix.GetUpperBound(1))
            {
                Console.WriteLine("Вiднiмання неможливе! Розмiри матриць повиннi бути однаковими");
            }
            else
            {
                //нова матриця різниці двох
                int[,] substractMatrix = new int[firstMatrix.GetUpperBound(0) + 1, firstMatrix.GetUpperBound(1) + 1];
                for (int i = 0; i < firstMatrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < firstMatrix.GetUpperBound(1) + 1; j++)
                    {
                        substractMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j]; //заповнюємо матрицю
                    }
                }

                //виводимо
                Console.WriteLine("Рiзниця двох матриць дорiвнює:");
                for (int i = 0; i < substractMatrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < substractMatrix.GetUpperBound(1) + 1; j++)
                    {
                        Console.Write(substractMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        //метод множення двох матриць
        public void Multiplication(int[,] firstMatrix, int[,] secondMatrix)
        {
            //перевірка чи можливе множення матриць
            if (firstMatrix.GetUpperBound(1) + 1 != secondMatrix.GetUpperBound(0) + 1)
            {
                Console.WriteLine("Множення неможливе! Кiлькiсть стовпцiв першої матрицi та кiлькiсть рядкiв " +
                    "другої матрицi повиннi бути однаковими");
            }
            else
            {
                //нова матриця добутку двох
                int[,] multipliedMatrix = new int[firstMatrix.GetUpperBound(0) + 1, secondMatrix.GetUpperBound(1) + 1];
                for (int i = 0; i < firstMatrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < secondMatrix.GetUpperBound(1) + 1; j++)
                    {
                        for (int k = 0; k < firstMatrix.GetUpperBound(1) + 1; k++)
                        {
                            multipliedMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j]; //заповнюємо матрицю
                        }
                    }
                }

                //виводимо
                Console.WriteLine("Добуток двох матриць дорiвнює:");
                for (int i = 0; i < multipliedMatrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < multipliedMatrix.GetUpperBound(1) + 1; j++)
                    {
                        Console.Write(multipliedMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        //метод множення матриці на число
        public void MnozhenyaNaSkalyar(int[,] matrix, int number)
        {
            //нова матриця добутку
            int[,] resultMatrix = new int[matrix.GetUpperBound(0) + 1, matrix.GetUpperBound(1) + 1];
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    resultMatrix[i, j] = matrix[i, j] * number; //заповнюємо матрицю
                }
            }

            //виводимо
            Console.WriteLine("Результат множення матрицi на скаляр:");
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        //метод транспонування матриці
        public void Transponuvanya(int[,] matrix)
        {
            //нова транспонована матриця
            int[,] transponovanaMatrix = new int[matrix.GetUpperBound(1) + 1, matrix.GetUpperBound(0) + 1];
            for (int i = 0; i < transponovanaMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < transponovanaMatrix.GetUpperBound(1) + 1; j++)
                {
                    transponovanaMatrix[i, j] = matrix[j, i]; //заповнюємо матрицю
                }
            }

            //виводимо
            Console.WriteLine("Транспонована матриця:");
            for (int i = 0; i < transponovanaMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < transponovanaMatrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(transponovanaMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        //метод перевірки чи рівні дві матриці
        public void IsEqual(int[,] firstMatrix, int[,] secondMatrix)
        {
            //спочатку перевіряємо рівність рядків і стовпців
            if (firstMatrix.GetUpperBound(0) == secondMatrix.GetUpperBound(0)
                && firstMatrix.GetUpperBound(1) == secondMatrix.GetUpperBound(1))
            {
                bool isEqual = true;
                for (int i = 0; i < firstMatrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < firstMatrix.GetUpperBound(1) + 1; j++)
                    {
                        //перевіряємо чи рівні значення матриць
                        if (firstMatrix[i, j] != secondMatrix[i, j])
                        {
                            isEqual = false;
                            break;
                        }
                    }
                }
                if (isEqual == false)
                {
                    Console.WriteLine("Матрицi не рiвнi");
                }
                else
                {
                    Console.WriteLine("Матрицi рiвнi");
                }
            }
            else
            {
                Console.WriteLine("Матрицi не рiвнi");
            }
        }

        //метод перевірки чи є матриця квадратною
        public bool IsSquare(int[,] matrix)
        {
            bool isSquare;
            //перевіряємо чи рівна к-сть рядків і стовпців
            if (matrix.GetUpperBound(0) == matrix.GetUpperBound(1))
            {
                isSquare = true;
            }
            else
            {
                isSquare = false;
            }

            return isSquare;
        }

        //метод перевірки на симетричність
        public void PerevirkaSumetruchnosti(int[,] matrix)
        {
            //спочатку перевіряємо чи є матриця квадратною
            if (IsSquare(matrix) == false)
            {
                Console.WriteLine("Перевiрка симетричностi неможлива! Матриця не є квадратною");
            }
            else
            {
                bool isSumetruchnaPoDiagonali = true; //булева змінна
                Console.WriteLine("Перевiрка симетричностi вiдносно головної дiагоналi");
                for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                    {
                        //перевіряємо чи дорівнюють значення відносно головної діагоналі
                        if (matrix[i, j] != matrix[j, i])
                        {
                            isSumetruchnaPoDiagonali = false;
                            break;
                        }
                    }
                }

                //перевіряємо значення булевої змінної і виводимо на консоль результат
                if (isSumetruchnaPoDiagonali == false)
                {
                    Console.WriteLine("Матриця не симетрична вiдносно головної дiагоналi");
                }
                else
                {
                    Console.WriteLine("Матриця симетрична вiдносно головної дiагоналi");
                }

                Console.WriteLine();
                Console.WriteLine("Перевiрка симетричностi вiдносно побiчної дiагоналi");
                isSumetruchnaPoDiagonali = true;
                for (int i = 1; i <= matrix.GetUpperBound(0); i++)
                {
                    for (int j = 1; j <= matrix.GetUpperBound(1); j++)
                    {
                        //перевіряємо чи дорівнюють значення відносно побічної діагоналі
                        if (matrix[i - 1, j - 1] != matrix[matrix.GetUpperBound(0) - j + 1, matrix.GetUpperBound(1) - i + 1])
                        {
                            isSumetruchnaPoDiagonali = false;
                            break;
                        }
                    }
                }

                //перевіряємо значення булевої змінної і виводимо на консоль результат
                if (isSumetruchnaPoDiagonali == false)
                {
                    Console.WriteLine("Матриця не симетрична вiдносно побiчної дiагоналi");
                }
                else
                {
                    Console.WriteLine("Матриця симетрична вiдносно побiчної дiагоналi");
                }
            }
        }

        //метод запису в json файл
        public void JsonSer(Matrix matrix)
        {
            using StreamWriter sw = new StreamWriter("matrix.json", false);
            string json = JsonSerializer.Serialize(matrix); //серіалізація
            sw.Write(json); //записуємо в файл
            Console.WriteLine("Matrix has been saved to file");
        }

        //метод десеріалізації з json файлу
        public Matrix JsonDes()
        {
            using StreamReader sr = new StreamReader("matrix.json");
            string json = sr.ReadLine(); //зчитуємо з файлу
            Matrix matrix = JsonSerializer.Deserialize<Matrix>(json); //десеріалізація

            return matrix;
        }
    }
}

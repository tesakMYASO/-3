using System;

namespace ClassLibrary1

{
    public class MatrixHelper
    {
       
        public static int CountDistinctColumns(int[,] matrix)
        {
            int m = matrix.GetLength(0); // Число строк
            int n = matrix.GetLength(1); // Число столбцов
            int count = 0; // Счетчик столбцов с различными элементами

            for (int j = 0; j < n; j++) // Итерация по столбцам
            {
                bool allDistinct = true; 

                for (int i = 0; i < m - 1; i++) 
                {
                    for (int k = i + 1; k < m; k++) 
                    {
                        if (matrix[i, j] == matrix[k, j]) 
                        {
                            allDistinct = false; 
                            break; 
                        }
                    }

                    if (!allDistinct)
                    {
                        break; 
                    }
                }

                if (allDistinct)
                {
                    count++; // Увеличение счетчика
                }
            }

            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            int[,] matrix = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            int distinctColumnsCount = MatrixHelper.CountDistinctColumns(matrix);

            Console.WriteLine($"Количество столбцов с различными элементами: {distinctColumnsCount}");
            Console.ReadKey();
        }
    }
}

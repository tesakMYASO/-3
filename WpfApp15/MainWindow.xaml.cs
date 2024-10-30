using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary1;

namespace WpfApp15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                int m = int.Parse(RowsTextBox.Text);
                int n = int.Parse(ColumnsTextBox.Text);

                int[,] matrix = new int[m, n];   // Создание матрицы


                string[] inputValues = InputTextBox.Text.Split(' ');
                int count = 0;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = int.Parse(inputValues[count]);
                        count++;
                    }
                }

                
                int[] maxElements = FindMaxInColumns(matrix, m, n);

                
                ResultTextBox.Text = "Максимальные элементы в каждом столбце:\n";  // Вывод результата в текстовое поле
                for (int i = 0; i < n; i++)
                {
                    ResultTextBox.Text += $"Столбец {i + 1}: {maxElements[i]}\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private int[] FindMaxInColumns(int[,] matrix, int m, int n)
        {
            int[] maxElements = new int[n];

            for (int j = 0; j < n; j++)
            {
                maxElements[j] = int.MinValue; // Инициализация минимальным значением

                for (int i = 0; i < m; i++)
                {
                    if (matrix[i, j] > maxElements[j])
                    {
                        maxElements[j] = matrix[i, j];
                    }
                }
            }

            return maxElements;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
       


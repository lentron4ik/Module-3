using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace zd5
{
    public partial class MainWindow : Window
    {
        public delegate List<int> SortDelegate(List<int> numbers);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            // Чтение чисел из TextBox
            var numbersString = NumbersTextBox.Text;
            var numbers = ParseNumbers(numbersString);

            // Определяем выбранный метод сортировки
            SortDelegate sortMethod = null;
            if (SortingMethodComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "Сортировка пузырьком")
                {
                    sortMethod = BubbleSort;
                }
                else if (selectedItem.Content.ToString() == "Быстрая сортировка")
                {
                    sortMethod = QuickSort;
                }
            }

            // Сортируем числа и измеряем время сортировки
            if (sortMethod != null)
            {
                var stopwatch = Stopwatch.StartNew(); // Запускаем таймер
                var sortedNumbers = sortMethod(numbers);
                stopwatch.Stop(); // Останавливаем таймер

                // Вывод отсортированных чисел
                SortedNumbersTextBox.Text = string.Join(", ", sortedNumbers);

                // Вывод времени сортировки
                SortTimeTextBlock.Text = $"Время сортировки: {stopwatch.ElapsedMilliseconds} мс";
            }
        }

        // Парсинг чисел из строки
        private List<int> ParseNumbers(string input)
        {
            return input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => int.TryParse(n.Trim(), out var num) ? num : 0)
                        .ToList();
        }

        // Сортировка пузырьком
        private List<int> BubbleSort(List<int> numbers)
        {
            var sorted = new List<int>(numbers);
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                for (int j = 0; j < sorted.Count - 1 - i; j++)
                {
                    if (sorted[j] > sorted[j + 1])
                    {
                        // Обмен значениями
                        var temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }
            return sorted;
        }

        // Быстрая сортировка
        private List<int> QuickSort(List<int> numbers)
        {
            if (numbers.Count <= 1)
                return numbers;

            var pivot = numbers[numbers.Count / 2];
            var less = numbers.Where(x => x < pivot).ToList();
            var equal = numbers.Where(x => x == pivot).ToList();
            var greater = numbers.Where(x => x > pivot).ToList();

            return QuickSort(less).Concat(equal).Concat(QuickSort(greater)).ToList();
        }
    }
}

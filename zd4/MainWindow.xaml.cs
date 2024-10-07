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

namespace zd4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Список данных с датами
        private List<DateItem> data = new List<DateItem>
        {
            new DateItem { Date = new DateTime(2023, 1, 15), Description = "Собака" },
            new DateItem { Date = new DateTime(2023, 2, 20), Description = "Кошка" },
            new DateItem { Date = new DateTime(2023, 3, 10), Description = "Попугай" },
            new DateItem { Date = new DateTime(2023, 4, 5), Description = "Слон" },
            new DateItem { Date = new DateTime(2023, 5, 25), Description = "Лев" },
            new DateItem { Date = new DateTime(2023, 6, 30), Description = "Тигр" },
            new DateItem { Date = new DateTime(2023, 7, 14), Description = "Лошадь" },
            new DateItem { Date = new DateTime(2023, 8, 19), Description = "Медведь" },
            new DateItem { Date = new DateTime(2023, 9, 10), Description = "Зебра" },
            new DateItem { Date = new DateTime(2023, 10, 1), Description = "Фламинго" }
        };

        // Делегат для фильтрации
        public delegate bool FilterDelegate(DateItem item, string filter);

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных в ListBox
        private void LoadData()
        {
            DataListBox.ItemsSource = data;
        }

        // Обработчик кнопки для применения фильтра
        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            string filterText = FilterTextBox.Text;
            FilterDelegate filter = null;

            // Определяем выбранный метод фильтрации
            if (FilterMethodComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "Фильтр по ключевым словам")
                {
                    filter = FilterByKeyword;
                }
                else if (selectedItem.Content.ToString() == "Фильтр по дате")
                {
                    filter = FilterByDate;
                }
            }

            if (filter != null)
            {
                // Применение фильтрации
                var filteredData = data.Where(item => filter(item, filterText)).ToList();
                DataListBox.ItemsSource = filteredData;
            }
        }

        // Метод фильтрации по ключевым словам
        private bool FilterByKeyword(DateItem item, string filter)
        {
            return item.Description.ToLower().Contains(filter.ToLower());
        }

        // Метод фильтрации по дате
        private bool FilterByDate(DateItem item, string filter)
        {
            if (DateTime.TryParse(filter, out DateTime filterDate))
            {
                return item.Date.Date == filterDate.Date;
            }
            return false;
        }
    }
}

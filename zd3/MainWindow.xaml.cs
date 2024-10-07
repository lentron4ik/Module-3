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

namespace zd3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Список задач
        private List<TaskItem> tasks = new List<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeDelegateComboBox();  
        }

        private void InitializeDelegateComboBox()
        {
            DelegateComboBox.Items.Add("Отправить уведомление");
            DelegateComboBox.Items.Add("Записать в журнал");
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, что текст не пустой и действие выбрано
            if (!string.IsNullOrWhiteSpace(TaskDescriptionTextBox.Text) && DelegateComboBox.SelectedItem != null)
            {
                var task = new TaskItem
                {
                    Description = TaskDescriptionTextBox.Text,
                    TaskAction = GetSelectedAction() // Получаем делегат для выполнения
                };

                tasks.Add(task); // Добавляем задачу в список
                TaskListBox.Items.Add(task.Description); // Отображаем описание задачи в списке
                TaskDescriptionTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите описание задачи и выберите действие.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Метод для получения выбранного действия
        private Action<string> GetSelectedAction()
        {
            // Возвращает делегат в зависимости от выбранного действия в комбобоксе
            if (DelegateComboBox.SelectedItem.ToString() == "Отправить уведомление")
            {
                return SendNotification; // Возвращаем метод для отправки уведомления
            }
            else if (DelegateComboBox.SelectedItem.ToString() == "Записать в журнал")
            {
                return LogToFile; // Возвращаем метод для записи в журнал
            }
            return null; // Если ничего не выбрано
        }

        private void ExecuteTasksButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var task in tasks)
            {
                // Выполнение действия через делегат
                task.TaskAction.Invoke(task.Description);
            }
            tasks.Clear();
            TaskListBox.Items.Clear();
        }


        #region " Методы для обработки уведомлений "
        // Метод для отправки уведомления
        private void SendNotification(string message)
        {
            MessageBox.Show($"Уведомление: {message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Метод для записи в журнал
        private void LogToFile(string message)
        {
            MessageBox.Show($"Записано в журнал: {message}", "Журнал", MessageBoxButton.OK, MessageBoxImage.Information);
        } 
        #endregion
    }
}

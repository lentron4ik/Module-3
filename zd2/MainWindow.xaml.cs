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

namespace zd2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Notification _notification;

        public MainWindow()
        {
            InitializeComponent();
            _notification = new Notification();

            // Подписка на события
            _notification.MessageSent += Notification_MessageSent;
            _notification.CallMade += Notification_CallMade;
            _notification.EmailSent += Notification_EmailSent;
        }

        // Обработчик события отправки сообщения
        private void Notification_MessageSent(object sender, string message)
        {
            MessageBox.Show($"Сообщение отправлено: {message}");
        }

        // Обработчик события совершения звонка
        private void Notification_CallMade(object sender, string phoneNumber)
        {
            MessageBox.Show($"Звонок на номер: {phoneNumber}");
        }

        // Обработчик события отправки электронного письма
        private void Notification_EmailSent(object sender, string email)
        {
            MessageBox.Show($"Электронное письмо отправлено на: {email}");
        }

        // Кнопка отправки сообщения
        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            _notification.SendMessage(MessageTextBox.Text);
        }

        // Кнопка совершения звонка
        private void MakeCallButton_Click(object sender, RoutedEventArgs e)
        {
            _notification.MakeCall(CallTextBox.Text);
        }

        // Кнопка отправки электронного письма
        private void SendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            _notification.SendEmail(EmailTextBox.Text);
        }
    }
}

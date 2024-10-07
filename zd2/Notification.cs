using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2
{
    public class Notification
    {
        // Определение событий для уведомлений
        public event EventHandler<string> MessageSent;
        public event EventHandler<string> CallMade;
        public event EventHandler<string> EmailSent;

        // Метод для отправки сообщения
        public void SendMessage(string message)
        {
            // Генерация события MessageSent
            MessageSent?.Invoke(this, message);
        }

        // Метод для совершения звонка
        public void MakeCall(string phoneNumber)
        {
            // Генерация события CallMade
            CallMade?.Invoke(this, phoneNumber);
        }

        // Метод для отправки электронного письма
        public void SendEmail(string email)
        {
            // Генерация события EmailSent
            EmailSent?.Invoke(this, email);
        }
    }
}
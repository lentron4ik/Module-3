using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd3
{

    public class TaskItem
    {
        public string Description { get; set; } // Описание задачи
        public Action<string> TaskAction { get; set; } // Делегат для выполнения задачи
    }
}

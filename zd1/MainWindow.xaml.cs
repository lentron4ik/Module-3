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

namespace zd1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Делегат для вычисления площади фигуры
        public delegate double AreaDelegate();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            AreaDelegate areaDelegate = null;

            // Проверяем, какая фигура выбрана пользователем
            if (CircleRadioButton.IsChecked == true)
            {
                double radius = double.Parse(RadiusTextBox.Text);
                Circle circle = new Circle(radius);
                areaDelegate = circle.CalculateArea;
            }
            else if (RectangleRadioButton.IsChecked == true)
            {
                double width = double.Parse(WidthTextBox.Text);
                double height = double.Parse(HeightTextBox.Text);
                Rectangle rectangle = new Rectangle(width, height);
                areaDelegate = rectangle.CalculateArea;
            }
            else if (TriangleRadioButton.IsChecked == true)
            {
                double baseLength = double.Parse(BaseTextBox.Text);
                double height = double.Parse(HeightTextBoxForTriangle.Text);
                Triangle triangle = new Triangle(baseLength, height);
                areaDelegate = triangle.CalculateArea;
            }

            // Вычисление площади через делегат
            if (areaDelegate != null)
            {
                double area = areaDelegate.Invoke();
                MessageBox.Show($"Площадь фигуры: {area}");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите фигуру.");
            }
        }
    }
}

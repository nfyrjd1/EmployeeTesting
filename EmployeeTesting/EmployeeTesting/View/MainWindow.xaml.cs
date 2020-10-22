using EmployeeTesting.Services;
using EmployeeTesting.View.EmployeeView;
using EmployeeTesting.View.ResultView;
using EmployeeTesting.View.TestView;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeTesting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new EmployeePage());
        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeePage());
        }

        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TestPage());
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ResultPage());
        }
    }
}

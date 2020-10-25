using EmployeeTesting.Model;
using EmployeeTesting.Services;
using EmployeeTesting.View.ResultView;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeTesting.View.TestView
{
    /// <summary>
    /// Логика взаимодействия для TestingPage.xaml
    /// </summary>
    public partial class TestingPage : Page
    {
        private Test _currentTest;
        private Test_Result _currentTestResult;
        public TestingPage(Test test)
        {
            InitializeComponent();

            _currentTest = test;
            _currentTestResult = new Test_Result();
            _currentTestResult.Test = _currentTest;

            EmployeeComboBox.ItemsSource = EmployeeTestingEntities.GetContext().Employee.ToList();
            EmployeeComboBox.DataContext = _currentTestResult;
            DataContext = _currentTest;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (_currentTestResult.Employee == null)
            {
                Errors.AppendLine("Вы не выбрали сотрудника!");
            }

            if (_currentTest.Test_Question.Any(p => string.IsNullOrEmpty(p.UserAnswer)))
            {
                Errors.AppendLine("Вы не указали ответ на один из вопросов!");
            }

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                int TestErrors = _currentTestResult.SetPoints();
                EmployeeTestingEntities.GetContext().Test_Result.Add(_currentTestResult);
                EmployeeTestingEntities.GetContext().SaveChanges();

                MessageBox.Show($"Набрано баллов: {_currentTestResult.Points}. Количество ошибок: {TestErrors}.", 
                    "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.Navigate(new ResultPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using EmployeeTestingMobile.Model.Classes;
using EmployeeTestingMobile.View.ResultView;
using System;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeTestingMobile.View.TestView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestingPage : ContentPage
    {
        private Test _currentTest;
        private TestResult _currentTestResult;
        public TestingPage(Test test)
        {
            InitializeComponent();

            _currentTest = test;
            _currentTestResult = new TestResult();
            _currentTestResult.Test = _currentTest;

            try
            {
                EmployeePicker.ItemsSource = App.Database.GetEmployee();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }

            EmployeePicker.BindingContext = _currentTestResult;
            BindingContext = _currentTest;
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (_currentTestResult.Employee == null)
            {
                Errors.AppendLine("Вы не выбрали сотрудника!");
            }

            if (_currentTest.Questions.Any(p => string.IsNullOrEmpty(p.UserAnswer)))
            {
                Errors.AppendLine("Вы не указали ответ на один из вопросов!");
            }

            if (Errors.Length > 0)
            {
                DisplayAlert("Ошибка", Errors.ToString(), "OK");
                return;
            }

            try
            {
                int TestErrors = _currentTestResult.SetPoints();
                App.Database.AddTestResult(_currentTestResult);
                DisplayAlert("Информация", $"Набрано баллов: {_currentTestResult.Points} . Количество ошибок: {TestErrors}.", "OK");

                Navigation.PopAsync();
                Navigation.PushAsync(new ResultPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}
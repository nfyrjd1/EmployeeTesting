using EmployeeTestingMobile.Model.Classes;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeTestingMobile.View.ResultView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        private void ResultPage_Appearing(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            try
            {
                ResultData.ItemsSource = App.Database.GetTestResult();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            TestResult DeleteItem = (sender as Button).BindingContext as TestResult;
            var action = await DisplayAlert("Необходимо подтверждение", "Вы действительно хотите удалить выбранный результат тестирования?", "Да", "Нет");
            if (action)
            {
                try
                {
                    App.Database.DeleteTestResult(DeleteItem);
                    UpdateData();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", ex.Message, "OK");
                }
            }
        }
    }
}
using EmployeeTestingMobile.Model.Classes;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeTestingMobile.View.TestView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        private void EditBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestAddEdit((sender as Button).BindingContext as Test));
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            Test DeleteItem = (sender as Button).BindingContext as Test;
            var action = await DisplayAlert("Необходимо подтверждение", "Вы действительно хотите удалить выбранный тест?", "Да", "Нет");
            if (action)
            {
                try
                {
                    if (App.Database.GetTestResult().Where(p => p.ID_Test == DeleteItem.ID_Test).Count() > 0)
                    {
                        await DisplayAlert("Ошибка", "С данным тестом связаны некоторые результаты тестирования, его невозможно удалить.", "OK");
                        return;
                    }

                    App.Database.DeleteTest(DeleteItem);
                    UpdateData();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", ex.Message, "OK");
                }
            }
        }

        private void UpdateData()
        {
            try
            {
                TestData.ItemsSource = App.Database.GetTest();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestAddEdit(null));
        }

        private void TestPage_Appearing(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void TestBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestingPage((sender as Button).BindingContext as Test));
        }
    }
}
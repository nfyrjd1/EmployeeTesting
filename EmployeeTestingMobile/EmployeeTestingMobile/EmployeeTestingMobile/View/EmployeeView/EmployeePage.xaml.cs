using EmployeeTestingMobile.Model.Classes;
using EmployeeTestingMobile.View.EmployeeView;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeTestingMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeePage : ContentPage
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void EditBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmployeeAddEdit((sender as Button).BindingContext as Employee));
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            Employee DeleteItem = (sender as Button).BindingContext as Employee;
            var action = await DisplayAlert("Необходимо подтверждение", "Вы действительно хотите удалить выбранного сотрудника?", "Да", "Нет");
            if (action)
            {
                try
                {
                    if (App.Database.GetTestResult().Where(p => p.ID_Employee == DeleteItem.ID_Employee).Count() > 0)
                    {
                        await DisplayAlert("Ошибка", "С данным сотрудником связаны некоторые результаты тестирования, его невозможно удалить.", "OK");
                        return;
                    }

                    App.Database.DeleteEmployee(DeleteItem);
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
                EmployeeData.ItemsSource = App.Database.GetEmployee();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmployeeAddEdit(null));
        }

        private void EmployeePage_Appearing(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}

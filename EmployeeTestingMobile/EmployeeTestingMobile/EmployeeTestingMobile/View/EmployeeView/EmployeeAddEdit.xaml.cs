using EmployeeTestingMobile.Model.Classes;
using System;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeTestingMobile.View.EmployeeView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeAddEdit : ContentPage
    {
        private Employee _currentEmployee;
        public EmployeeAddEdit(Employee employee)
        {
            InitializeComponent();
            try
            {
                PositionPicker.ItemsSource = App.Database.GetPosition();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }

            if (employee == null) employee = new Employee();

            _currentEmployee = employee;
            BindingContext = _currentEmployee;
            
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (string.IsNullOrEmpty(_currentEmployee.Surname))
            {
                Errors.AppendLine("Вы не заполнили фамилию сотрудника!");
            }

            if (string.IsNullOrEmpty(_currentEmployee.Name))
            {
                Errors.AppendLine("Вы не заполнили имя сотрудника!");
            }

            if (string.IsNullOrEmpty(_currentEmployee.Middlename))
            {
                Errors.AppendLine("Вы не заполнили отчество сотрудника!");
            }

            if (_currentEmployee.Position == null)
            {
                Errors.AppendLine("Вы не заполнили должность сотрудника!");
            }

            if (Errors.Length > 0)
            {
                DisplayAlert("Ошибка", Errors.ToString(), "OK");
                return;
            }

            try
            {
                if (_currentEmployee.ID_Employee == 0)
                {
                    App.Database.AddEmployee(_currentEmployee);
                }
                else
                {
                    App.Database.UpdateEmployee(_currentEmployee);
                }

                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}
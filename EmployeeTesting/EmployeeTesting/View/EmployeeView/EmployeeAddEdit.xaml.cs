using EmployeeTesting.Model;
using EmployeeTesting.Services;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeTesting.View.EmployeeView
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddEdit.xaml
    /// </summary>
    public partial class EmployeeAddEdit : Page
    {
        private Employee _currentEmployee;
        public EmployeeAddEdit(Employee employee)
        {
            InitializeComponent();
            PositionComboBox.ItemsSource = EmployeeTestingEntities.GetContext().Position.ToList();

            if (employee == null) employee = new Employee();

            _currentEmployee = employee;
            DataContext = _currentEmployee;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show(Errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {

                if (_currentEmployee.ID_Employee == 0)
                {
                    EmployeeTestingEntities.GetContext().Employee.Add(_currentEmployee);
                }

                EmployeeTestingEntities.GetContext().SaveChanges();
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

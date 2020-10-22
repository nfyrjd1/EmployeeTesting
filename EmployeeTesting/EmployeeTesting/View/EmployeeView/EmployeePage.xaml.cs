using EmployeeTesting.Model;
using EmployeeTesting.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeTesting.View.EmployeeView
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void EmployeePage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible && Manager.MainFrame.Content == this)
            {
                UpdateEmployeeData();
            }
        }

        private void UpdateEmployeeData()
        {
            try
            {
                EmployeeTestingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                EmployeeData.ItemsSource = EmployeeTestingEntities.GetContext().Employee.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeeAddEdit(null));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeeAddEdit((sender as Button).DataContext as Employee));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee DeleteItem = (sender as Button).DataContext as Employee;
            if (MessageBox.Show("Вы действительно хотите удалить выбранного сотрудника?", "Необходимо подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                try
                {
                    if (DeleteItem.Test_Result.Count > 0)
                    {
                        MessageBox.Show("С данным сотрудником связаны некоторые результаты тестирования, его невозможно удалить.", 
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    EmployeeTestingEntities.GetContext().Employee.Remove(DeleteItem);
                    EmployeeTestingEntities.GetContext().SaveChanges();
                    UpdateEmployeeData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

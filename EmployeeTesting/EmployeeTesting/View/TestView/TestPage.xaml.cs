using EmployeeTesting.Model;
using EmployeeTesting.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeTesting.View.TestView
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
        }

        private void TestPage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible && Manager.MainFrame.Content == this)
            {
                UpdateTestData();
            }
        }

        private void UpdateTestData()
        {
            try
            {
                EmployeeTestingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                TestData.ItemsSource = EmployeeTestingEntities.GetContext().Test.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TestAddEdit(null));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TestAddEdit((sender as Button).DataContext as Test));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Test DeleteItem = (sender as Button).DataContext as Test;
            if (MessageBox.Show("Вы действительно хотите удалить выбранный тест?", "Необходимо подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                try
                {
                    if (DeleteItem.Test_Result.Count > 0)
                    {
                        MessageBox.Show("С данным тестом связаны некоторые результаты тестирования, его невозможно удалить.",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    EmployeeTestingEntities.GetContext().Test_Question.RemoveRange(DeleteItem.Test_Question);
                    EmployeeTestingEntities.GetContext().Test.Remove(DeleteItem);
                    EmployeeTestingEntities.GetContext().SaveChanges();
                    UpdateTestData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TestingPage((sender as Button).DataContext as Test));
        }
    }
}

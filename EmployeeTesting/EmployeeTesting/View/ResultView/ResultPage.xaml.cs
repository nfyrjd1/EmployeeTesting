using EmployeeTesting.Model;
using EmployeeTesting.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeTesting.View.ResultView
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        private void ResultPage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible && Manager.MainFrame.Content == this)
            {
                UpdateResultData();
            }
        }

        private void UpdateResultData()
        {
            try
            {
                EmployeeTestingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ResultData.ItemsSource = EmployeeTestingEntities.GetContext().Test_Result.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Test_Result> Results = EmployeeTestingEntities.GetContext().Test_Result.ToList();
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = ".csv|*.csv";
                dialog.DefaultExt = ".csv";
                dialog.AddExtension = true;

                if (dialog.ShowDialog() == true)
                {
                    StringBuilder exportData = new StringBuilder();
                    exportData.AppendLine("№;Тест;Сотрудник;Набрано баллов;Результат;");
                    for (int i = 0; i < Results.Count; i++)
                    {
                        exportData.AppendLine($"{i + 1};{Results[i].Test.Test_Title};{Results[i].Employee.FullName};{Results[i].Points};{Results[i].Status};");
                    }
                    File.WriteAllText(dialog.FileName, exportData.ToString(), Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            Test_Result DeleteItem = (sender as Button).DataContext as Test_Result;
            if (MessageBox.Show("Вы действительно хотите удалить выбранный результат тестирования?", "Необходимо подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                try
                {
                    EmployeeTestingEntities.GetContext().Test_Result.Remove(DeleteItem);
                    EmployeeTestingEntities.GetContext().SaveChanges();
                    UpdateResultData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

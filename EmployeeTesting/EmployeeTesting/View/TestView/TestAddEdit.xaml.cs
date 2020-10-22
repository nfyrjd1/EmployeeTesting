using EmployeeTesting.Model;
using EmployeeTesting.Services;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeTesting.View.TestView
{
    /// <summary>
    /// Логика взаимодействия для TestAddEdit.xaml
    /// </summary>
    public partial class TestAddEdit : Page
    {
        private Test _currentTest;
        public TestAddEdit(Test test)
        {
            InitializeComponent();

            if (test == null)
            {
                test = new Test();
            }

            _currentTest = test;
            DataContext = _currentTest;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (string.IsNullOrEmpty(_currentTest.Test_Title))
            {
                Errors.AppendLine("Вы не указали название теста!");
            }

            if (_currentTest.Test_Question.Count == 0)
            {
                Errors.AppendLine("Вы не добавили ни одного вопроса!");
            }

            if (_currentTest.Test_Question.Any(p => string.IsNullOrEmpty(p.Question)))
            {
                Errors.AppendLine("Вы не указали текст одного из вопросов!");
            }

            if (_currentTest.Test_Question.Any(p => string.IsNullOrEmpty(p.Answer)))
            {
                Errors.AppendLine("Вы не указали ответ на один из вопросов!");
            }

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                if (_currentTest.ID_Test == 0)
                {
                    EmployeeTestingEntities.GetContext().Test.Add(_currentTest);
                }

                EmployeeTestingEntities.GetContext().SaveChanges();
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Test_Question NewQuestion = new Test_Question();
                NewQuestion.Test = _currentTest;
                _currentTest.Test_Question.Add(NewQuestion);
                QuestionsData.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Test_Question DeleteItem = (sender as Button).DataContext as Test_Question;
            if (MessageBox.Show("Вы действительно хотите удалить выбранный вопрос?", "Необходимо подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                try
                {
                    if (_currentTest.Test_Question.Count == 1)
                    {
                        MessageBox.Show("Невозможно удалить единственный вопрос!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    _currentTest.Test_Question.Remove(DeleteItem);
                    QuestionsData.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

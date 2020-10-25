using EmployeeTestingMobile.Model.Classes;
using System;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeTestingMobile.View.TestView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestAddEdit : ContentPage
    {
        private Test _currentTest;
        public TestAddEdit(Test test)
        {
            InitializeComponent();

            if (test == null) test = new Test();

            _currentTest = test;
            BindingContext = _currentTest;
        }

        private async void DeleteQuestionBtn_Clicked(object sender, EventArgs e)
        {
            TestQuestion DeleteItem = (sender as Button).BindingContext as TestQuestion;
            var action = await DisplayAlert("Необходимо подтверждение", "Вы действительно хотите удалить выбранный вопрос?", "Да", "Нет");
            if (action)
            {
                try
                {
                    if (_currentTest.Questions.Count == 1)
                    {
                        await DisplayAlert("Ошибка", "Невозможно удалить единственный вопрос!", "OK");
                        return;
                    }
                    _currentTest.Questions.Remove(DeleteItem);

                    UpdateQuestions();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", ex.Message, "OK");
                }
            }
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void UpdateQuestions()
        {
            var list = QuestionsData.ItemsSource;
            QuestionsData.ItemsSource = null;
            QuestionsData.ItemsSource = list;
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (string.IsNullOrEmpty(_currentTest.Test_Title))
            {
                Errors.AppendLine("Вы не указали название теста!");
            }

            if (_currentTest.Passing_Points.HasValue)
            {
                if (_currentTest.Passing_Points.Value < 0)
                {
                    Errors.AppendLine("Количество баллов не может быть отрицательным!");
                }
            }

            if (_currentTest.Questions.Count == 0)
            {
                Errors.AppendLine("Вы не добавили ни одного вопроса!");
            }

            if (_currentTest.Questions.Any(p => string.IsNullOrEmpty(p.Question)))
            {
                Errors.AppendLine("Вы не указали текст одного из вопросов!");
            }

            if (_currentTest.Questions.Any(p => string.IsNullOrEmpty(p.Answer)))
            {
                Errors.AppendLine("Вы не указали ответ на один из вопросов!");
            }

            foreach (TestQuestion question in _currentTest.Questions)
            {
                if (question.Points.HasValue)
                {
                    if (question.Points.Value < 0)
                    {
                        Errors.AppendLine("Количество баллов не может быть отрицательным!");
                    }
                }
            }

            if (Errors.Length > 0)
            {
                DisplayAlert("Ошибка", Errors.ToString(), "OK");
                return;
            }

            try
            {
                if (_currentTest.ID_Test == 0)
                {
                    App.Database.AddTest(_currentTest);
                }
                else
                {
                    App.Database.UpdateTest(_currentTest);
                }

                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        private void AddQuestionBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                TestQuestion NewQuestion = new TestQuestion();
                _currentTest.Questions.Add(NewQuestion);
                UpdateQuestions();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}
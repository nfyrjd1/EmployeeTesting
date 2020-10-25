using System.Collections.Generic;
using EmployeeTestingMobile.Model.Classes;
using System.Linq;

namespace EmployeeTestingMobile.Model
{
    public partial class DataBase
    {
        public void AddTest(Test test)
        {
            _db.Insert(test);

            int testId = GetTest().Last().ID_Test;

            foreach (TestQuestion question in test.Questions)
            {
                question.ID_Test = testId;
                AddTestQuestion(question);
            }
        }

        public List<Test> GetTest()
        {
            List<Test> list = _db.Table<Test>().ToList();
            foreach (Test test in list)
            {
                test.Questions = GetTestQuestion().Where(p => p.ID_Test == test.ID_Test).ToList();
            }

            return list;
        }

        public void UpdateTest(Test test)
        {
            Test prevTest = GetTest().Find(p => p.ID_Test == test.ID_Test);
            foreach (TestQuestion question in prevTest.Questions)
            {
                if (test.Questions.Find(p => p.ID_Test_Question == question.ID_Test_Question) == null)
                {
                    DeleteTestQuestion(question);
                    continue;
                }
            }

            foreach (TestQuestion question in test.Questions)
            {
                if (question.ID_Test_Question == 0)
                {
                    question.ID_Test = test.ID_Test;
                    AddTestQuestion(question);
                }
                else UpdateTestQuestion(question);
            }

            _db.Update(test);
        }

        public void DeleteTest(Test test)
        {
            foreach (TestQuestion question in test.Questions)
            {
                DeleteTestQuestion(question);
            }
            _db.Delete(test);
        }
    }
}

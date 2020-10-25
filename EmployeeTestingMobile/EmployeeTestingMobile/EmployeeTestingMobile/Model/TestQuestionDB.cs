using System.Collections.Generic;
using EmployeeTestingMobile.Model.Classes;

namespace EmployeeTestingMobile.Model
{
    public partial class DataBase
    {
        public List<TestQuestion> GetTestQuestion()
        {
            return _db.Table<TestQuestion>().ToList();
        }

        public void DeleteTestQuestion(TestQuestion question)
        {
            _db.Delete(question);
        }

        public void UpdateTestQuestion(TestQuestion question)
        {
            _db.Update(question);
        }

        public void AddTestQuestion(TestQuestion question)
        {
            _db.Insert(question);
        }
    }
}

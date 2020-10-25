using EmployeeTestingMobile.Model.Classes;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeTestingMobile.Model
{
    public partial class DataBase
    {
        public void AddTestResult(TestResult result)
        {
            result.ID_Employee = result.Employee.ID_Employee;
            result.ID_Test = result.Test.ID_Test;
            _db.Insert(result);
        }

        public List<TestResult> GetTestResult()
        {
            List<TestResult> list = _db.Table<TestResult>().ToList();
            foreach (TestResult result in list)
            {
                result.Test = GetTest().Where(p => p.ID_Test == result.ID_Test).FirstOrDefault();
                result.Employee = GetEmployee().Where(p => p.ID_Employee == result.ID_Employee).FirstOrDefault();
            }

            return list;
        }

        public void DeleteTestResult(TestResult result)
        {
            _db.Delete(result);
        }
    }
}

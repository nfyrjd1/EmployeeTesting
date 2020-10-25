using EmployeeTestingMobile.Model.Classes;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeTestingMobile.Model
{
    public partial class DataBase
    {
        public void AddEmployee(Employee employee)
        {
            employee.ID_Position = employee.Position.ID_Position;
            _db.Insert(employee);
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> list = _db.Table<Employee>().ToList();
            foreach (Employee employee in list)
            {
                employee.Position = GetPosition().Where(p => p.ID_Position == employee.ID_Position).First();
            }

            return list;
        }

        public void UpdateEmployee(Employee employee)
        {
            employee.ID_Position = employee.Position.ID_Position;
            _db.Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _db.Delete(employee);
        }
    }
}

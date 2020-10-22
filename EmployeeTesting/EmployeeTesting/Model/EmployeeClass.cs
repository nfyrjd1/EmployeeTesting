namespace EmployeeTesting.Model
{
    partial class Employee
    {
        public string FullName
        {
            get
            {
                return $"{Surname} {Name} {Middlename}";
            }
        }
    }
}

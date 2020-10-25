using SQLite;

namespace EmployeeTestingMobile.Model.Classes
{
    [Table("Employee")]
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int ID_Employee { get; set; }

        [MaxLength(80), NotNull]
        public string Name { get; set; }

        [MaxLength(80), NotNull]
        public string Surname { get; set; }

        [MaxLength(80), NotNull]
        public string Middlename { get; set; }

        [NotNull]
        public int ID_Position { get; set; }

        [Ignore]
        public Position Position { get; set; }

        [Ignore]
        public string FullName
        {
            get
            {
                return $"{Surname} {Name} {Middlename}";
            }
        }

        public Employee()
        {

        }
    }
}

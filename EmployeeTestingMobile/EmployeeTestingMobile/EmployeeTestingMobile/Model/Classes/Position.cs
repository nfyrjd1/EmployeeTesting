using SQLite;

namespace EmployeeTestingMobile.Model.Classes
{
    [Table("Position")]
    public class Position
    {
        [PrimaryKey, AutoIncrement]
        public int ID_Position { get; set; }

        [MaxLength(50), NotNull]
        public string Name { get; set; }

        public Position()
        {
            
        }
    }
}

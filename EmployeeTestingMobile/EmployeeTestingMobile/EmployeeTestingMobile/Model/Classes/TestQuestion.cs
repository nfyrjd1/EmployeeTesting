using SQLite;

namespace EmployeeTestingMobile.Model.Classes
{
    [Table("Test_Question")]
    public class TestQuestion
    {
        [PrimaryKey, AutoIncrement]
        public int ID_Test_Question { get; set; }
        
        [NotNull]
        public int ID_Test { get; set; }
        
        [NotNull]
        public string Question { get; set; }

        [NotNull]
        public string Answer { get; set; }

        public int? Points { get; set; }

        [Ignore]
        public string UserAnswer { get; set; }
    }
}

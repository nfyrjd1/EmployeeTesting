using SQLite;

namespace EmployeeTestingMobile.Model.Classes
{
    [Table("Test_Result")]
    public class TestResult
    {
        [PrimaryKey, AutoIncrement]
        public int ID_Test_Result { get; set; }

        [NotNull]
        public int ID_Employee { get; set; }

        [NotNull]
        public int ID_Test { get; set; }

        public int? Points { get; set; }

        [Ignore]
        public Employee Employee { get; set; }

        [Ignore]
        public Test Test { get; set; }

        [Ignore]
        public string Status
        {
            get
            {
                if (Points.HasValue && Test.Passing_Points.HasValue)
                {
                    if (Points.Value < Test.Passing_Points.Value)
                        return "Не пройден";
                }

                return "Пройден";
            }
        }

        public int SetPoints()
        {
            int errors = 0;
            int PointsSum = 0;
            foreach (TestQuestion question in Test.Questions)
            {
                if (question.Points.HasValue && question.Answer.ToLower() == question.UserAnswer.ToLower())
                    PointsSum += question.Points.Value;
                else errors++;
            }
            Points = PointsSum;

            return errors;
        }
    }
}

using System.Collections.Generic;
using SQLite;

namespace EmployeeTestingMobile.Model.Classes
{
    [Table("Test")]
    public class Test
    {
        [PrimaryKey, AutoIncrement]
        public int ID_Test { get; set; }

        [NotNull]
        public string Test_Title { get; set; }

        public int? Passing_Points { get; set; }

        [Ignore]
        public List<TestQuestion> Questions { get; set; }

        [Ignore]
        public int QuestionsCount
        {
            get
            {
                return Questions.Count;
            }
        }

        [Ignore]
        public int MaxPoints
        {
            get
            {
                int PointsSum = 0;
                Questions.ForEach((p) =>
                {
                    if (p.Points.HasValue) PointsSum += p.Points.Value;
                });

                return PointsSum;
            }
        }

        public Test()
        {
            Questions = new List<TestQuestion>();
        }
    }
}

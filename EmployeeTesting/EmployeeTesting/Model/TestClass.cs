using System.Linq;

namespace EmployeeTesting.Model
{
    partial class Test
    {
        public int QuestionsCount
        {
            get
            {
                return Test_Question.Count;
            }
        }

        public int MaxPoints
        {
            get
            {
                int PointsSum = 0;
                Test_Question.ToList().ForEach((p) =>
                {
                    if (p.Points.HasValue) PointsSum += p.Points.Value;
                });

                return PointsSum;
            }
        }
    }
}

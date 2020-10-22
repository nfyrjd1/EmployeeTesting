namespace EmployeeTesting.Model
{
    partial class Test_Result
    {
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
            foreach(Test_Question question in Test.Test_Question)
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

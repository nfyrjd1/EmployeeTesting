using System.Collections.Generic;
using EmployeeTestingMobile.Model.Classes;

namespace EmployeeTestingMobile.Model
{
    public partial class DataBase
    {
        public void AddPosition(Position position)
        {
            _db.Insert(position);
        }

        public List<Position> GetPosition()
        {
            return _db.Table<Position>().ToList();
        }
    }
}

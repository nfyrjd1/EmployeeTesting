using System;

namespace EmployeeTesting.Model
{
    partial class EmployeeTestingEntities
    {
        private static EmployeeTestingEntities _context;

        public static EmployeeTestingEntities GetContext()
        {
            if (_context == null)
                _context = new EmployeeTestingEntities();

            return _context;
        }
    }
}

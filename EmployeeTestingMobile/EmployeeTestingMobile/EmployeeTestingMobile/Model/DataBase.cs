using EmployeeTestingMobile.Model.Classes;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace EmployeeTestingMobile.Model
{
    public partial class DataBase
    {
        private SQLiteConnection _db;

        public void ConnectDb(string dbPath)
        {
            if (_db == null) _db = new SQLiteConnection(dbPath);
        }

        public DataBase(string dbPath)
        {
            bool IsFirstStart = !File.Exists(dbPath);
            ConnectDb(dbPath);
            _db.CreateTable<Position>();
            _db.CreateTable<Employee>();
            _db.CreateTable<Test>();
            _db.CreateTable<TestQuestion>();
            _db.CreateTable<TestResult>();

            if (IsFirstStart)
            {
                Position Welder = new Position { Name = "Сварщик" };
                Position Cleaner = new Position { Name = "Уборщик" };
                Position Secretary = new Position { Name = "Секретарь" };
                Position Booker = new Position { Name = "Бухгалтер" };
                Position Programmer = new Position { Name = "Программист на C#" };
                Position Economist = new Position { Name = "Экономист" };
                AddPosition(Cleaner);
                AddPosition(Secretary);
                AddPosition(Booker);
                AddPosition(Welder);
                AddPosition(Programmer);
                AddPosition(Economist);

                Employee Sindeeva = new Employee { Surname = "Синдеева", Name = "Рада", Middlename = "Тихоновна", Position = Welder };
                Employee Uglova = new Employee { Surname = "Углова", Name = "Розалия", Middlename = "Александровна", Position = Programmer };
                Employee Tena = new Employee { Surname = "Тэна", Name = "Агафья", Middlename = "Павеловна", Position = Programmer };
                AddEmployee(Sindeeva);
                AddEmployee(Uglova);
                AddEmployee(Tena);
                AddEmployee(new Employee { Surname = "Жикин", Name = "Феофан", Middlename = "Сократович", Position = Economist }); 
                AddEmployee(new Employee { Surname = "Уржумцев", Name = "Елисей", Middlename = "Егорович", Position = Cleaner }); 
                AddEmployee(new Employee { Surname = "Тихомиров", Name = "Роман", Middlename = "Ильевич", Position = Secretary }); 
                AddEmployee(new Employee { Surname = "Висенина", Name = "Лилия", Middlename = "Серафимовна", Position = Welder });
                AddEmployee(new Employee { Surname = "Волошин", Name = "Давид", Middlename = "Геннадиевич", Position = Booker });

                Test Theology = new Test
                {
                    Test_Title = "Богословие",
                    Passing_Points = 25,
                    Questions = new List<TestQuestion> {
                        new TestQuestion { Question = "Принято ли было в древней Церкви сидеть во время богослужения при чтении или пении псалмов?", Answer = "Нет", Points = 5 },
                        new TestQuestion { Question = "Является ли абортом, т. е. тяжким грехом, операция при внематочной беременности?", Answer="Нет", Points=5 },
                        new TestQuestion { Question = "Иоанн Кассиан Римлянин говорил, что тот, кто не преодолел эту страсть, не вступил даже на первую ступень веры. Что это за страсть?", Answer="Чревоугодие", Points = 5 },
                        new TestQuestion { Question = "О Введении во Храм Пресвятой Богородицы сообщает:", Answer="Священное Предание", Points = 5 },
                        new TestQuestion { Question = "Аборт по большей части совершается по причине:", Answer="Сребролюбия", Points = 5 },
                        new TestQuestion { Question = "Какое установление имеет Таинство Миропомазания?", Answer="Божественное", Points = 5 },
                        new TestQuestion { Question = "С какой части новоначальному лучше начинать чтение Библии?", Answer="С Нового Завета", Points = 5 }
                        }
                };
                AddTest(Theology);

                AddTestResult(new TestResult { Test = Theology, Employee = Sindeeva, Points = 25 });
                AddTestResult(new TestResult { Test = Theology, Employee = Uglova, Points = 20 });
                AddTestResult(new TestResult { Test = Theology, Employee = Tena, Points = 35 });
            }
        }
    }
}

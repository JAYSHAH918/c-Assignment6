using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Enum;
//using System.Collections.Generic.List;

    class Program
    {
        public List<Employee> employeeList;
        public List<Salary> salaryList;
       // public int i;

        public Program()
        {
            employeeList = new List<Employee> 
            { 
			new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
			new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
			new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
			new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
			new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
			new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
			new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}			
		};

            salaryList = new List<Salary> {
			new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
		};
        }

        public static void Main()
        {
            Program program = new Program();

            program.Task1();

            program.Task2();

            program.Task3();
        }

        public void Task1()
        {

           var Total= (from sal in salaryList
             join emp in employeeList on sal.EmployeeID equals emp.EmployeeID
             where sal.EmployeeID == i
             group new { sal, emp } by emp.EmployeeFirstName into salGroup
             select new
             {
                 //n = salGroup.Key,
                 v = salGroup.Sum(x => x.sal.Amount),
             }
                         );

            
           Console.WriteLine(" "+Total);
           Console.ReadKey();
                //Implementation
        }

        public void Task2()
        {
            
            var M = (from sal in salaryList
                     join emp in employeeList on sal.EmployeeID equals emp.EmployeeID
                     where sal.EmployeeID == i
                     group new {sal,emp} by sal.Type into salGroup
                     select new
                     {
                         n = salGroup.Key,
                         a=employeeList.Count.CompareTo(employeeList),
                     )};
            //Implementation
        }

        public void Task3()
        {
            var M = (from sal in salaryList
                     join emp in employeeList on sal.EmployeeID equals emp.EmployeeID
                     where sal.EmployeeID == i
                     group new {sal,emp} by sal.Type into salGroup
                     select new
                     {
                         n = salGroup.Key,
                         //m = salGroup.Sum(x=>x.sal
                        b= salGroup.Average(x=>x.sal.Type.Equals(SalaryType.Bonus,"Bonus")),
                         c= salGroup.Average(x=>x.sal.Type.Equals(SalaryType.Monthly,"Monthly")),
                         d=salGroup.Average(x=>x.sal.Type.Equals(SalaryType.Performance,"Performance")),
                     });

            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);

            //Implementation
        }

        public int i { get; set; }
    }

    public enum SalaryType
    {
        Monthly,
        Performance,
        Bonus
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int Age { get; set; }
    }

    public class Salary
    {
        public int EmployeeID { get; set; }
        public int Amount { get; set; }
        public SalaryType Type { get; set; }
    }


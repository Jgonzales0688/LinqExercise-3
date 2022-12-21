using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("********************************");

            //TODO: Print the Average of numbers
            Console.WriteLine(numbers.Average());
            Console.WriteLine("********************************");

            //TODO: Order numbers in ascending order and print to the console
            numbers.OrderBy(num => num).ToList().ForEach(num => Console.WriteLine(num));
            Console.WriteLine("********************************");

            //TODO: Order numbers in decsending order and print to the console
            numbers.OrderByDescending(num => num).ToList().ForEach(num => Console.WriteLine(num));
            Console.WriteLine("********************************");
            //TODO: Print to the console only the numbers greater than 6
            numbers.Where(num => num > 6).ToList().ForEach(num => Console.WriteLine(num));
            Console.WriteLine("********************************");
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var numOrder = numbers.ToList();

            foreach (int num in numOrder.Take(4))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("********************************");
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(34, 4);

            numbers.OrderByDescending(num => num).ToList().ForEach(num => Console.WriteLine(num));
            Console.WriteLine("********************************");

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();
            Console.WriteLine("********************************");
            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            employees.FindAll(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's')
                .ToList().ForEach(name => Console.WriteLine(name.FullName));
            Console.WriteLine("********************************");
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.


            var nameList = employees.Where(name => name.Age > 26).OrderBy(age => age.Age).ThenBy(name => name.FirstName);
            nameList.ToList().ForEach(name => Console.WriteLine($"{name.FullName}, {name.Age}"));
            Console.WriteLine("********************************");

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sum = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35).Sum(num => num.YearsOfExperience);
            var avg = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35).Average(num => num.YearsOfExperience);

            Console.WriteLine($"Sum is {sum}, average is {avg}");
            Console.WriteLine("********************************");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees.Append(new Employee("Gonzales", "Jessica", 0, 0)).ToList().ForEach(x => Console.WriteLine(x.FullName));
            Console.WriteLine("********************************");

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}

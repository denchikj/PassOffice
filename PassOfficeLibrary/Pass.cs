using PassOfficeLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassOfficeLibrary
{
    public class Pass
    {
        public List<Employee> employees = new List<Employee>();       

        public void AddPass(Guid id, int passNumber, string firstName, string lastName, string patronymic, int passTypes)
        {
            employees.Add(new Employee(id, passNumber, firstName, lastName, patronymic, passTypes, DateTime.Now));
            Console.WriteLine("Пропуск добавлен\n" +
                "Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        public void DeletePass(string name)
        {
            bool found = false;
            foreach (Employee employee in employees)
            {
                if (employee.LastName.Contains(name))
                {
                    found = true;
                    Console.WriteLine($"Пропуск для {employee.LastName} удален");
                    employees.Remove(employee);
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"Фамилия {name} не найдена\n" +
                    "Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }
        }
        public int CheckNumber()
        {
            int number = 1;
            foreach (Employee employee in employees)
            {
                if (employee.PassNumber > number)
                {
                    number = employee.PassNumber;
                }
            }
            return number;
        }

        public DateTime LastDate
        {
            get
            {
                Employee lastData = employees.Last();
                return lastData.PassDate;
            }
        }

        public int Amount(DateTime date1, DateTime date2)
        {
            int amount = 0;
            foreach (Employee employee in employees)
            {
                if (DateTime.Compare(employee.PassDate, date1) > 0 && DateTime.Compare(employee.PassDate, date2) < 0)
                {
                    amount++;
                }
            }
            return amount;
        }
    }
}

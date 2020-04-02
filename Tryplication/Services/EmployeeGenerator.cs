using System;
using System.Collections.Generic;
using Tryplication.Models;

namespace Tryplication.Services
{
    public class EmployeeGenerator : IEmployeeGenerator
    {
        IEnumerable<Employee> IEmployeeGenerator.GenerateEmployees(int employeeNumber)
        {
            List<Employee> result = new List<Employee>
            {
                new Employee()
                {
                    Id = 1,
                    Name = "John",
                    Position = Constants.Posisiton.JuniorDeveloper,
                    PhoneNumber = "2020202001"
                },

                new Employee()
                {
                    Id = 2,
                    Name = "Matt",
                    Position = Constants.Posisiton.SeniorDeveloper,
                    PhoneNumber = "1010101001"
                },

                new Employee()
                {
                    Id = 3,
                    Name = "Tim",
                    Position = Constants.Posisiton.MiddleDeveloper,
                    PhoneNumber = "03030330301"
                },

                new Employee()
                {
                    Id = 4,
                    Name = "Terrance",
                    Position = Constants.Posisiton.JuniorDeveloper,
                    PhoneNumber = "02222000001"
                },

                new Employee()
                {
                    Id = 5,
                    Name = "Tadokoro",
                    Position = Constants.Posisiton.SeniorDeveloper,
                    PhoneNumber = "012321421301"
                }
            };

            return result;
        }
    }
}
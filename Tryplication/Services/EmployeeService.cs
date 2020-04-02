using System.Collections.Generic;
using System.Linq;
using Tryplication.Models;

namespace Tryplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> employees;
        private readonly IEmployeeGenerator employeeGenerator;

        public EmployeeService(IEmployeeGenerator employeeGenerator)
        {
            employees = new List<Employee>();
            this.employeeGenerator = employeeGenerator;
            Initialize();
        }

        private void Initialize()
        {
            employees.AddRange(employeeGenerator.GenerateEmployees(5));
        }

        public void Add(Employee employee)
        {
            lock (employee)
            {
                employees.Add(employee);
            }
        }

        public void Delete(long employeeID)
        {
            lock (employees)
            {
                employees.RemoveAll(s => s.Id == employeeID);
            }
        }

        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        public void Update(Employee employee)
        {
            lock (employees)
            {
                Employee employeeToUpate = employees.Single(s => s.Id == employee.Id);
                employeeToUpate.Name = employee.Name;
                employeeToUpate.Position = employee.Position;
                employeeToUpate.PhoneNumber = employee.PhoneNumber;
            }
        }
    }
}
using System.Collections.Generic;
using Tryplication.Models;

namespace Tryplication.Services
{
    public interface IEmployeeGenerator
    {
        IEnumerable<Employee> GenerateEmployees(int employeeNumber);
    }
}
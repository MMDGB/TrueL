using System.Collections.Generic;
using Tryplication.Models;

namespace Tryplication.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> Get();

        void Add(Employee employee);

        void Update(Employee employee);

        void Delete(long employeeId);
    }
}
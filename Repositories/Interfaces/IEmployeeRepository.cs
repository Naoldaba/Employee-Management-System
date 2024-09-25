using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeMgtAPI.Models;

namespace EmployeeMgtAPI.Repositories.Interfaces
{
    // Interface that defines the contract for accessing and managing Employee data.
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}

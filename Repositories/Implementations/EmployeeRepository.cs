using EmployeeMgtAPI.Data;
using EmployeeMgtAPI.Models;
using EmployeeMgtAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgtAPI.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbCtx _context;

        public EmployeeRepository(ApplicationDbCtx context)
        {
            _context = context;
        }

        // Get all employees
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error while fetching employees from the database.");
            }
        }

        //Get specific employee
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return await _context.Employees.FindAsync(id);
            }
            catch (Exception)
            {
                throw new Exception($"Error while fetching employee with Id {id}.");
            }
        }

        // Create Employee
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception)
            {
                throw new Exception("Error while creating a new employee.");
            }
        }

        //Update Employee
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            try
            {
                var existingEmployee = await _context.Employees.FindAsync(id);
                if (existingEmployee == null)
                {
                    return null; 
                }

                if (!string.IsNullOrEmpty(employee.FirstName))
                {
                    existingEmployee.FirstName = employee.FirstName;
                }

                if (!string.IsNullOrEmpty(employee.MiddleName))
                {
                    existingEmployee.MiddleName = employee.MiddleName;
                }

                if (!string.IsNullOrEmpty(employee.LastName))
                {
                    existingEmployee.LastName = employee.LastName;
                }

                await _context.SaveChangesAsync();

                return existingEmployee;
            }
            catch (Exception)
            {
                throw new Exception($"Error while updating employee with Id {employee.Id}.");
            }
        }

        // Delete Employee
        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw new Exception($"Error while deleting employee with Id {id}.");
            }
        }
    }
}

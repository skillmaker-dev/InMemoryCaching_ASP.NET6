using DataAccess.Models;

namespace DataAccess
{
    public interface ISampleData
    {
        List<Employee> GetEmployees();
        Task<List<Employee>> GetEmployeesAsync();
        Task<List<Employee>> GetEmployeesCached();
    }
}
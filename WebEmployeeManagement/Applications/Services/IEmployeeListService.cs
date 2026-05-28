using WebEmployeeManagement.Applications.Domains;

namespace WebEmployeeManagement.Applications.Services;

public interface IEmployeeListService
{
    List<Employee> GetEmployees();
    Department GetById(int id);
    List<Department> GetDepartments();
    
}
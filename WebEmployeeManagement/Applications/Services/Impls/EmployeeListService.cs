using WebEmployeeManagement.Applications.Repositories;
using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Exceptions;
using WebEmployeeManagement.Infrastructures.Context;
namespace WebEmployeeManagement.Applications.Services.Impls;

public class EmployeeListService : IEmployeeListService
{
        private readonly IEmployeeRepository _employeeRepository;
            private readonly IDepartmentRepository _departmentRepository;
    public EmployeeListService(
        AppDbContext context,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository)
    {

        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }



        public List<Employee> GetEmployees()
    {
        return _employeeRepository.FindAll();
    }
        public Department GetById(int id)
    {
        var result = _departmentRepository.FindById(id)!;
        if (result == null)
        {
            throw new NotFoundException($"部署Id{id}に該当する部署は存在しません");
        }
        return result;
    }


}
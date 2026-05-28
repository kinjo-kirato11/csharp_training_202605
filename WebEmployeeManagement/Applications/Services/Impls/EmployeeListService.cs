using WebEmployeeManagement.Applications.Repositories;
using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Exceptions;
using WebEmployeeManagement.Infrastructures.Context;
namespace WebEmployeeManagement.Applications.Services.Impls;

public class EmployeeListService : IEmployeeListService
{
        private readonly IEmployeeRepository _employeeRepository;

            public EmployeeListService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

        public List<Employee> GetEmployees()
    {
        return _employeeRepository.FindAll();
    }

}
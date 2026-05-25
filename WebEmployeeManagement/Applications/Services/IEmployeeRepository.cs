using WebEmployeeManagement.Infrastructures.Entities;

namespace WebEmployeeManagement.Applications.Interfaces;

public interface IEmployeeRepository
{
    List<Employee> GetAll();
    Employee? Find(int employeeId);
    bool ExistsById(int employeeId);
    bool HasEmployees(int employeeId);
    void Add(Employee employee);
    void MoveEmployees(int fromEmployeeId, int toEmployeeId);
    void SaveChanges();
}
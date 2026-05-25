using WebEmployeeManagement.Infrastructures.Entities;

namespace WebEmployeeManagement.Applications.Services;

public interface IDepartmentRepository
{
    List<Department> GetAll();
    Department? Find(int departmentId);
    bool ExistsById(int departmentId);
    bool HasEmployees(int departmentId);
    void Add(Department department);
    void MoveEmployees(int fromDepartmentId, int toDepartmentId);
    void SaveChanges();
}
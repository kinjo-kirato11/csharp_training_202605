using WebEmployeeManagement.Infrastructures.Entities;

namespace WebEmployeeManagement.Applications.Services;

public record DepartmentSaveResult(bool Succeeded, string? ErrorMessage);
public record DepartmentDeleteResult(bool Succeeded, string? ErrorMessage);

public interface IDepartmentService
{
    List<Department> GetAll();
    Department? Find(int departmentId);
    bool HasEmployees(int departmentId);
    DepartmentSaveResult Create(Department department);
}
public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public List<Department> GetAll()
    {
        return _departmentRepository.GetAll();
    }

    public Department? Find(int departmentId)
    {
        return _departmentRepository.Find(departmentId);
    }

    public bool HasEmployees(int departmentId)
    {
        return _departmentRepository.HasEmployees(departmentId);
    }

    public DepartmentSaveResult Create(Department department)
    {
        if (_departmentRepository.ExistsById(department.DepartmentId))
        {
            return new DepartmentSaveResult(false, "同一IDの部署が既に存在しています。");
        }

        try
        {
            _departmentRepository.Add(department);
            _departmentRepository.SaveChanges();
            return new DepartmentSaveResult(true, null);
        }
        catch (Exception ex)
        {
            // ログ出力などのエラーハンドリングを行う
            return new DepartmentSaveResult(false, $"部署の保存中にエラーが発生しました: {ex.Message}");
        }
    }
}
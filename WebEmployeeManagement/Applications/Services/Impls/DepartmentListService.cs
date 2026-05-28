using WebEmployeeManagement.Applications.Repositories;
using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Exceptions;
using WebEmployeeManagement.Infrastructures.Context;
namespace WebEmployeeManagement.Applications.Services.Impls;
/// <summary>
/// 従業員登録サービスインターフェイスの実装
/// </summary>
public class DepartmentListService : IDepartmentListService
{
    
  

    /// <summary>
    /// ドメインオブジェクト:部署のCRUD操作インターフェイス
    /// </summary>
    private readonly IDepartmentRepository _departmentRepository;

     public DepartmentListService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public List<Department> GetDepartments()
    {
        return _departmentRepository.FindAll();
    }
}
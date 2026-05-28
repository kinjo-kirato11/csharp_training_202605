using WebEmployeeManagement.Applications.Adapters;
using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Infrastructures.Entities;
namespace WebEmployeeManagement.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクト:EmployeeとEmployeeEntityの相互変換インターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Employee</typeparam>
/// <typeparam name="TTarget">EmployeeEntity</typeparam>
public class EmployeeEntityAdapter :
IConverter<Employee, EmployeeEntity>, IRestorer<Employee, EmployeeEntity>
{
    /// <summary>
    /// ドメインオブジェクト:EmployeeをEmployeeEntityに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:従業員</param>
    /// <returns>EmployeeEntity</returns>
    public EmployeeEntity Convert(Employee domain)
    {
        var entity = new EmployeeEntity
        {
            EmpName = domain.Name
        };
        if (domain.Id != null)
        {
            entity.EmpId = domain.Id.Value;
        }
        if (domain.Department != null)
        {
            entity.DeptId = domain.Department.Id;
        }
        return entity;
    }

    /// <summary>
    /// EmployeeEntityからドメインオブジェクト:Employeeを復元する
    /// </summary>
    /// <param name="target">EmployeeEntity</param>
    /// <returns>ドメインオブジェクト:Employee</returns>
    public Employee Restore(EmployeeEntity target)
    {
        var employee = new Employee(
            target.EmpId,
            target.EmpName,
            null
        );
        return employee;
    }
        public Employee ToDomain(EmployeeEntity source)
    {
        if (source == null)
            throw new ArgumentNullException("引数がnullのため復元できません。");
        Department? department = null;
        // 部署がnulでない
        if (source.Department != null)
        {
            // 所属部署を生成する
            department = new Department(source.Department.DeptId, source.Department.DeptName, null);
        }
        // 社員を生成して返す
        var employee = new Employee(source.DeptId, source.EmpName, department);
        return employee;
    }
      public List<Employee> ToDomainList(List<EmployeeEntity> sources)
    {
        if (sources == null)
            throw new ArgumentNullException("引数がnullのため復元できません。");
        // Employeeのリストを生成する
        var employees = new List<Employee>();
        // EmployeeEntityのリストからEmployeeのリストへ変換する
        foreach (var source in sources)
        {
            employees.Add(ToDomain(source));
        }
        return employees;
    }
}
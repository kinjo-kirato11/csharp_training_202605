using WebEmployeeManagement.Applications.Adapters;
using WebEmployeeManagement.Applications.Domains;

namespace WebEmployeeManagement.Presentations.ViewModels;

/// <summary>
/// EmployeeRegisterViewModel(従業員登録ViewModel)を
/// ドメインオブジェクト:Employeeに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Employee</typeparam>
/// <typeparam name="TTarget">EmployeeRegisterForm</typeparam>
public class DepatmentRegisterViewModelAdapter : IRestorer<Department, DepartmentRegisterViewModel>
{
    /// <summary>
    /// EmployeeRegisterViewModelをドメインオブジェクト:Employeeに変換する
    /// </summary>
    /// <param name="target">EmployeeRegisterViewModel</param>
    /// <returns>ドメインオブジェクト:Employee</returns>
    public Department Restore(DepartmentRegisterViewModel target)
    {
        // Department(部署)を作成する
        var department = new Department(target.DeptId!.Value, target.DeptName);
        return department;
    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebEmployeeManagement.Applications.Domains;
namespace WebEmployeeManagement.Presentations.ViewModels;
/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class DepartmentRegisterViewModel
{
    /// <summary>
    /// 氏名
    /// </summary>
    ///     [Display(Name = "部署名")]
    /// 
    [Display(Name = "部署名")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    public string? DeptName { get; set; } = string.Empty;

    [Display(Name = "部署番号")]
    public int? DeptId { get; set; } = 0;



    public override string ToString()
    {
        return $"DeptId={DeptId} , DeptName={DeptName}";
    }
}
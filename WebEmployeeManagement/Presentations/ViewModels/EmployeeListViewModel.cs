using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebEmployeeManagement.Applications.Domains;
namespace WebEmployeeManagement.Presentations.ViewModels;   
   public class EmployeeListViewModel
{
        public int? EmpId { get; set; } = 0;


    public string? Name { get; set; } = string.Empty;
    /// <summary>
    /// 所属部署
    /// </summary>

  

    /// <summary>
    /// 選択された部署名
    /// </summary>
    public string? DeptName { get; set; } = string.Empty;


    public override string ToString()
    {
        return $"Name={Name} , DeptName={DeptName}";
    }
    
}
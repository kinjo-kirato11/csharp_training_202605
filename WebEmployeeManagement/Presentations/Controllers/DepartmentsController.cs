using Microsoft.AspNetCore.Mvc;
using WebEmployeeManagement.Infrastructures.Entities;
using WebEmployeeManagement.Infrastructures.Context;
using WebEmployeeManagement.Applications.Services;

namespace WebEmployeeManagement.Presentations.Controllers;


    [Route("Departmet")]
public class DepartmentsController : Controller
{

    private readonly IDepartmentListService _departmentListService;

    public DepartmentsController(IDepartmentListService departmentListService)
    {
        _departmentListService = departmentListService;
    }

    [HttpGet("Index")]
    public IActionResult Index()
    {
        var departments = _departmentListService.GetDepartments();
        return View(departments);
    }

}
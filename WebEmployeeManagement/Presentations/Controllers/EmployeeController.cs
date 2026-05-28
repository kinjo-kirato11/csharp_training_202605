using Microsoft.AspNetCore.Mvc;
using WebEmployeeManagement.Applications.Services;

namespace WebEmployeeManagement.Presentations.Controllers;

[Route("Employee")]
public class EmployeesController : Controller
{
    private readonly IEmployeeListService _employeeListService;

    public EmployeesController(IEmployeeListService employeeListService)
    {
        _employeeListService = employeeListService;
    }

    [HttpGet("Index")]
    public IActionResult Index()
    {
        var employees = _employeeListService.GetEmployees();
        return View(employees);
    }
}
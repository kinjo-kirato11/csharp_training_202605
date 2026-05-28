using Microsoft.AspNetCore.Mvc;
using WebEmployeeManagement.Applications.Services;
using WebEmployeeManagement.Presentations.ViewModels;
namespace WebEmployeeManagement.Presentations.Controllers;

[Route("Employee")]
public class EmployeesController : Controller
{
    private readonly IEmployeeListService _employeeListService;
    private readonly EmployeeListViewModelAdapter _adapter;

    private readonly TempDataStore<EmployeeListViewModel> _empDataStore;



    public EmployeesController(IEmployeeListService employeeListService)
    {
        _employeeListService = employeeListService;
    }

    [HttpGet("Index")]
    public IActionResult Index()
    {
        List<EmployeeListViewModel> viewModel;
        viewModel = new List<EmployeeListViewModel>();

        // サービスに社員一覧を要求
        var employees = _employeeListService.GetEmployees();
        foreach (var employee in employees)
        {
            var elvm = new EmployeeListViewModel();
            elvm.EmpId = employee.Id;
            elvm.Name = employee.Name;
            elvm.DeptName = employee.Department?.Name;
            viewModel.Add(elvm);
        }


            return View(viewModel);
    }


}
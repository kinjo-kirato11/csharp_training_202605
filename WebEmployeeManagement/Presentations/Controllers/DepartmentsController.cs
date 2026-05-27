using Microsoft.AspNetCore.Mvc;
using WebEmployeeManagement.Infrastructures.Entities;
using WebEmployeeManagement.Infrastructures.Context;

namespace WebEmployeeManagement.Presentations.Controllers;

public class DepartmentsController : Controller
{
[Route("Departmet")]

    public IActionResult Index()
    {
        return View();
    }

}   
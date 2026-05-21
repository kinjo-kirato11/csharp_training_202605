using Microsoft.AspNetCore.Mvc;
using EmployeeList.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeList.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
}

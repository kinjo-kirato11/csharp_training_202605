using Microsoft.AspNetCore.Mvc;
using EmployeeList.Models;
using System.Collections.Generic;

namespace EmployeeList.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

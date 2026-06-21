using Microsoft.AspNetCore.Mvc;

namespace HomeworkManager.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => RedirectToAction("Index", "Tasks");
}

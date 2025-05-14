using DogsApp.Mvc.Models;
using DogsApp.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Mvc.Controllers;

public class DogsController : Controller
{
    static DogsService DogsService = new DogsService();
    [HttpGet("")]
    public IActionResult Index()
    {
        var model = DogsService.GetAllDogs();
        return View(model);
    }

    [HttpGet("create")]
    public IActionResult CreateDog()
    {
        return View();
    }
    [HttpPost("create")]
    public IActionResult CreateDog(Dog dog)
    {
        if (ModelState.IsValid)
        {
            DogsService.AddDog(dog);
            return RedirectToAction("Index");
        }
        return View(dog);
    }
}

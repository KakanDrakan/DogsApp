using DogsApp.Mvc.Models;
using DogsApp.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Mvc.Controllers;

public class DogsController : Controller
{
    static DogService DogsService = new DogService();
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

    [HttpGet("edit")]
    public IActionResult UpgradeDog()
    {
        return View();
    }

    [HttpPost("edit")]
    public IActionResult UpgradeDog(Dog dog)
    {
        return RedirectToAction("");
    }

    [HttpPost("delete")]
    public IActionResult DeleteDog(Dog dog)
    {
        DogsService.RemoveDog(dog);
        return RedirectToAction("Index");
    }
}

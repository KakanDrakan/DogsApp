using DogsApp.Mvc.Models;
using DogsApp.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Mvc.Controllers;

public class DogsController : Controller
{
    static DogService dogService = new DogService();
    [HttpGet("")]
    public IActionResult Index()
    {
        var model = dogService.GetAllDogs();
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
            dogService.AddDog(dog);
            return RedirectToAction("Index");
        }
        return RedirectToAction();
    }

    [HttpGet("edit/{id}")]
    public IActionResult EditDog(int id)
    {
        var model = dogService.GetDogById(id);
        return View(model);
    }

    [HttpPost("edit")]
    public IActionResult EditDog(Dog dog)
    {
        return RedirectToAction("Index");
    }

    [HttpPost("delete/{id}")]
    public IActionResult DeleteDog(int id)
    {
        dogService.RemoveDog(id);
        return RedirectToAction("Index");
    }
}

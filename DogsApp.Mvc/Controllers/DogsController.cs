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
        var dogs = dogService.GetAllDogs();
        return View(dogs);
    }

    [HttpGet("/create")]
    public IActionResult Create() => View();

    [HttpPost("/create")]
    public IActionResult Create(Dog dog)
    {
        if (ModelState.IsValid)
        {
            dogService.AddDog(dog);
            return RedirectToAction(nameof(Index));
        }
        return View(dog);
    }
}

using DogsApp.Mvc.Models;
using DogsApp.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Mvc.Controllers;

public class DogsController : Controller
{
    static DogService dogService = new DogService();
    public DogsController()
    {

    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var dogs = dogService.GetAllDogs();
        return View(dogs);
    }

    [HttpGet("create")]
    public IActionResult Create() => View();

    [HttpPost("create")]
    public IActionResult Create(Dog dog)
    {
        dogService.AddDog(dog);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet("edit/{id}")]
    public IActionResult Edit(int id) => View(dogService.GetDogById(id));

    [HttpPost("edit/{id}")]
    public IActionResult Edit(Dog dog, int id)
    {
        dogService.UppdateDog(dog);
        return RedirectToAction(nameof(Index));
    }
}

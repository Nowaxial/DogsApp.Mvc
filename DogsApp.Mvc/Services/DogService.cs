using DogsApp.Mvc.Models;

namespace DogsApp.Mvc.Services;

public class DogService
{
    List<Dog> dogs = new()
    {
        new Dog { Id = 1, Name = "Rex", Age = 5 },
        new Dog { Id = 2, Name = "Fido", Age = 3 },
        new Dog { Id = 3, Name = "Buddy", Age = 2 }
    };

    public Dog[] GetAllDogs() => dogs.OrderBy(d => d.Name).ToArray();

    public Dog? GetDogById(int id) => dogs.SingleOrDefault(d => d.Id == id);

    public void AddDog(Dog dog)
    {
        dog.Id = dogs.Max(d => d.Id) + 1;
        dogs.Add(dog);
    }

    internal void UppdateDog(Dog uppdatedDog)
    {
        
        Dog dog = GetDogById(uppdatedDog.Id);
        dog.Name = uppdatedDog.Name;
        dog.Age = uppdatedDog.Age;
    }
}

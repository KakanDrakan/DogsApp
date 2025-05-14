using DogsApp.Mvc.Models;

namespace DogsApp.Mvc.Services
{
    public class DogService
    {
        private List<Dog> _dogs = new List<Dog>
        {
            new Dog { Id = 1, Name = "Buddy", Age = 3 },
            new Dog { Id = 2, Name = "Max", Age = 5 },
            new Dog { Id = 3, Name = "Bella", Age = 2 }
        };

        public Dog AddDog(Dog dog)
        {

            if (_dogs.Count == 0)
            {
                dog.Id = 1;
            }
            else
            {
                dog.Id = _dogs.Max(d => d.Id) + 1;
            }
            
            _dogs.Add(dog);
            return dog;
        }

        public Dog[] GetAllDogs()
        {
            return _dogs.ToArray();
        }

        public Dog GetDogById(int id)
        {
            return _dogs.SingleOrDefault(d => d.Id == id);
        }

        public void RemoveDog(int id)
        {
            Dog dog = GetDogById(id);
            _dogs.Remove(dog);
        }
    }
}

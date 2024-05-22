using System.Collections.Generic;
using Tutorial6.Models;

namespace Tutorial6.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAnimals(string orderBy);
        Animal GetAnimalById(int id);
        void AddAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);
    }
}
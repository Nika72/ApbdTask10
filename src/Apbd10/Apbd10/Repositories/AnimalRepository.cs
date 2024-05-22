using System;
using System.Collections.Generic;
using System.Linq;
using Tutorial6.Data;
using Tutorial6.Models;

namespace Tutorial6.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalDbContext _context;

        public AnimalRepository(AnimalDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Animal> GetAnimals(string orderBy)
        {
            var animals = _context.Animals.AsQueryable();

            switch (orderBy.ToLower())
            {
                case "description":
                    animals = animals.OrderBy(a => a.Description);
                    break;
                case "category":
                    animals = animals.OrderBy(a => a.Category);
                    break;
                case "area":
                    animals = animals.OrderBy(a => a.Area);
                    break;
                default:
                    animals = animals.OrderBy(a => a.Name);
                    break;
            }

            return animals.ToList();
        }

        public Animal GetAnimalById(int id)
        {
            return _context.Animals.Find(id);
        }

        public void AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(Animal animal)
        {
            var existingAnimal = GetAnimalById(animal.Id);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Description = animal.Description;
                existingAnimal.Category = animal.Category;
                existingAnimal.Area = animal.Area;
                _context.SaveChanges();
            }
        }

        public void DeleteAnimal(int id)
        {
            var animal = GetAnimalById(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
        }
    }
}
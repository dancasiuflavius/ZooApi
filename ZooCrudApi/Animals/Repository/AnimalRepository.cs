using AutoMapper;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using ZooCrudApi.Animals.DTO;
using ZooCrudApi.Animals.Model;
using ZooCrudApi.Animals.Repository.Interfaces;
using ZooCrudApi.Data;

namespace ZooCrudApi.Animals.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public AnimalRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animals.ToListAsync();
        }
        public async Task<Animal> GetByNameAsync(string name)
        {
            return await _context.Animals.FirstOrDefaultAsync(product => product.Name.Equals(name));

        }
        public async Task<IEnumerable<Int32>> GetAllAsyncAge()
        {

            return await _context.Animals.Select(animal => animal.Age).ToListAsync();
        }

        public async Task<Animal> CreateAsync(CreateAnimalRequest animalRequest)
        {

            var product = _mapper.Map<Animal>(animalRequest);


            _context.Animals.Add(product);

            await _context.SaveChangesAsync();

            return product;

        }
        public async Task<IEnumerable<Animal>> SortAllByName()
        {
            return await _context.Animals.OrderBy(animal => animal.Name).ToListAsync();
        }
        public async Task<IEnumerable<Animal>> SortByUsersChoice(string propertyName)
        {
            try
            {
                var propertyInfo = typeof(Animal).GetProperty(propertyName);
                if (propertyInfo == null)
                {
                    throw new ArgumentException($"Property '{propertyName}' not found in Animal class.");
                }

                var animals = await _context.Animals
                    .AsQueryable()
                    .OrderBy($"{propertyName} ASC")
                    .ToListAsync();

                return animals;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while sorting. Please check the parameter: {ex.Message}");
                return new List<Animal>();
            }
        }
        public async Task<Animal> FindAnimal(int id)
        {

            return await _context.Animals.FindAsync(id);
            
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Animals.FindAsync(id);

            _context.Animals.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

using AutoMapper;
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
        public async Task<IEnumerable<Animal>> SortByUsersChoice(string parametre)
        {
            try
            {
                return await _context.Animals.Where(animal => animal.Equals(parametre)).ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Eroare la filtrare. Verificati parametrul : " + ex.Message);
                return await _context.Animals.ToListAsync();
            }
            
        }
    }
}

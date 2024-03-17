using ZooCrudApi.Animals.DTO;
using ZooCrudApi.Animals.Model;

namespace ZooCrudApi.Animals.Repository.Interfaces
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal> GetByNameAsync(string name);

        Task<IEnumerable<Int32>> GetAllAsyncAge();
        //Task<Product> GetByIdAsync(int id);
        Task<Animal> CreateAsync(CreateAnimalRequest animalRequest);
        Task<IEnumerable<Animal>> SortAllByName();
        //Task<Product> UpdateAsync(int id, UpdateProductRequest productRequest);
        //Task DeleteAsync(int id);
        Task<IEnumerable<Animal>> SortByUsersChoice(string parametre);
    }
}

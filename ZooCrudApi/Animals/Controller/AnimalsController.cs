using Microsoft.AspNetCore.Mvc;
using ZooCrudApi.Animals.Repository.Interfaces;
using ZooCrudApi.Animals.Model;
using ZooCrudApi.Animals.Repository;
using ZooCrudApi.Animals.DTO;

namespace ZooCrudApi.Animals.Controller
{
    [ApiController]
    [Route("animals")]
    public class AnimalsController : ControllerBase
    {

        private readonly ILogger<AnimalsController> _logger;

        private readonly IAnimalRepository _animalRepository;

        public AnimalsController(ILogger<AnimalsController> logger, IAnimalRepository animalRepository)
        {
            _logger = logger;
            _animalRepository = animalRepository;
        }
        [HttpGet("api/v1/all")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAll()
        {

            var products = await _animalRepository.GetAllAsync();
            return Ok(products);

        }
        [HttpGet("api/v1/getName/{name}")]
        public async Task<ActionResult<Animal>> GetName([FromRoute] string name)
        {
            var animal = await _animalRepository.GetByNameAsync(name);
            return Ok(animal);
        }
        [HttpGet("api/v1/getAllByAge")]
        public async Task<ActionResult<Double>> GetAllAsyncPrice()
        {
            var animal = await _animalRepository.GetAllAsyncAge();
            return Ok(animal);
        }

        [HttpPost("api/v1/create")]

        public async Task<ActionResult<Animal>> CreateProduct([FromBody] CreateAnimalRequest createAnimalRequest)
        {
            var product = await _animalRepository.CreateAsync(createAnimalRequest);


            return Ok(product);


        }
        [HttpPost("api/v1/sortByName")]
        public async Task<ActionResult<Animal>> SortAllByName()
        {
            var animal = await _animalRepository.SortAllByName();
            return Ok(animal);
        }
        [HttpGet("api/v1/sorting/{exemple}")]
        public async Task<ActionResult<Animal>> SortByChoice([FromRoute] string choice)
        {
            var animal = await _animalRepository.SortByUsersChoice(choice);
            return Ok(animal);
        }
    }
}


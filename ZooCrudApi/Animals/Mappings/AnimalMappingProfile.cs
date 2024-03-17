using AutoMapper;
using ZooCrudApi.Animals.DTO;
using ZooCrudApi.Animals.Model;

namespace ZooCrudApi.Products.Mappings
{
    public class AnimalMappingProfile : Profile
    {

        public AnimalMappingProfile()
        {



            CreateMap<CreateAnimalRequest, Animal>();
        }

    }
}

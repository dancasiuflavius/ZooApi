namespace ZooCrudApi.Animals.DTO
{
    public class UpdateAnimalRequest
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

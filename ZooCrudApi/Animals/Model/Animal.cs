using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooCrudApi.Animals.Model
{
    [Table("animals")]
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]

        public string Name { get; set; }
        [Required]
        [Column("category")]

        public string Category { get; set; }
        [Required]
        [Column("age")]

        public int Age { get; set; }
        [Required]
        [Column("date_of_birth")]

        public DateTime DateOfBirth { get; set; }
    }
}

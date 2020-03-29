using System.ComponentModel.DataAnnotations;

namespace CretaceousPark.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required]
        [StringLength(20)] // We specify that a Name can't be longer than twenty characters with [StringLength(20)].
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        [Range(0, 200, ErrorMessage = "Age must be between 0 and 200.")] // We provide a Range between 0 and 200 for Age. Note that we can also add a custom error message with ErrorMessage. If we don't provide a custom message, Entity will provide its own error message.
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
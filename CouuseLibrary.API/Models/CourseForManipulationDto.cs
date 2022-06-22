using CouuseLibrary.API.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace CouuseLibrary.API.Models
{
    [CourseTitleMustBeDifferenteFromDescription(
        ErrorMessage = "Title must be different from description.")]
    public abstract class CourseForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100, ErrorMessage = "The title shouldn't have more than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You should fill out a description.")]
        [MaxLength(1500, ErrorMessage = "The description shouldn't have more than 1500 characters.")]

        // Marcação do campo como virtual serve para que
        // possamos utilizar sua implementação da classe abstrata
        // porém também possamos modifica-la quando quisermos. 
        public virtual string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Web.Models.Genres
{
    public class EditGenreViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Името на жанра е задължително")]
        [StringLength(50, ErrorMessage = "Името на жанра не трябва да е по-дълго от 50 симбвола")]
        public string Name { get; set; }
    }
}

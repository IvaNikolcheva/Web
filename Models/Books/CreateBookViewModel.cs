using System.ComponentModel.DataAnnotations;

namespace Web.Models.Books
{
    public class CreateBookViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Заглавието на книгата е задължително")]
        [StringLength(200, ErrorMessage="Заглавието на книгата не трябва да е по-дълго от 200 симбвола")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Името на автора е задължително")]
        [StringLength(100, ErrorMessage = "Името на автора не трябва да е по-дълго от 100 симбвола")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Годината на издаване е задължителна")]
        [Range(1500,2025, ErrorMessage="Годината на издаване трябва да е от 1500 до 2025 година") ]
        public int Year {  get; set; }

        [Required(ErrorMessage = "Жанра на книгата е задължителен")]
        public int GenreId { get; set; }
    }
}

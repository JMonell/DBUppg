using System.ComponentModel.DataAnnotations.Schema;

namespace bibliotekssystem.Models{

    public class Book{
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Publisher { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public ICollection<BookAuthor> BookAuthors{get; set; } // many to many
        public ICollection<Loan> loans{get; set; } //one to many

    }
}   
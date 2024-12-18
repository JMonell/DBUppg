using System.ComponentModel.DataAnnotations.Schema;

namespace bibliotekssystem.Models{

    public class Author{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookAuthor> BookAuthors{get; set; } // many to many


    }
}   
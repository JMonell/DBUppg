// using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace bibliotekssystem.Models{

    public class Loan{

        public int Id { get; set; }
        public string BorrowerName { get; set; }
        public string BorrowerPhoneNumber { get; set; }
        
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }



}
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeveloperAssessmentFor_KnilaItSolutions.Models
{
    public class Book
    {
            [Key] // Designates this property as the primary key
        
            public Guid Id { get; set; }
      
            public string? Publisher { get; set; }
            public string? Title { get; set; }
            public string? AuthorLastName { get; set; }
            public string? AuthorFirstName { get; set; }
            public decimal Price { get; set; }
       
    }
}

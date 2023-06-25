using System.ComponentModel.DataAnnotations;

namespace Zadania.Models
{
    public class MovieText
    {
         [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string TextOriginalUrl { get; set; }
            public string TextUpdate1Url { get; set; }
            public string TextUpdate2Url { get; set; }
            public DateTime DateCreated { get; set; }
           
        
    }
}

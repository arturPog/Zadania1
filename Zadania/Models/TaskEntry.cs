using System.ComponentModel.DataAnnotations;

namespace Zadania.Models
{
    public class TaskEntry
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Duration { get; set; }
    }

}


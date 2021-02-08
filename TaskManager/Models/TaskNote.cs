using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskNote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comment { get; set; }
    }
}

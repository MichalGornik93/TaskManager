using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskNote
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}

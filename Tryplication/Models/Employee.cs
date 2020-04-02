using System.ComponentModel.DataAnnotations;

namespace Tryplication.Models
{
    public class Employee
    {
        [Required]
        public long? Id { get; set; }

        public string Name { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
    }
}
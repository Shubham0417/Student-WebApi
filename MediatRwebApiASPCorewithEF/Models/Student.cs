using System.ComponentModel.DataAnnotations;

namespace MediatRwebApiASPCorewithEF.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public int Standard { get; set; }
        public string? IsDeleted { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}

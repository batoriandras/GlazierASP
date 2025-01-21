using Entities.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Employee : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime DateOfEmployment { get; set; }

        public virtual ICollection<Service>? Services { get; set; }

        public Employee()
        {
        }

        public Employee(string id, string userId, DateTime dateOfEmployment)
        {
            Id = id;
            UserId = userId;
            DateOfEmployment = dateOfEmployment;
        }
    }
}

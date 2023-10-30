using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace API.Models.Entities
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        [StringLength(255)]
        public string? Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]   // default value DateTime.Now
        public DateTime CreatedAt { get; set; }
    }
}

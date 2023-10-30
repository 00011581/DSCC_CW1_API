using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set;}

        [Required]
        public string Body { get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]   // default value DateTime.Now
        public DateTime CreatedAt { get; set; } 

        [Required]
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}

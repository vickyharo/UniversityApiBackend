using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course : BaseEntity
    {

        [Required, StringLength(int.MaxValue)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string LargeDescription { get; set; } = string.Empty;

        [Required]
        public string ObjetivePublic { get; set; } = string.Empty;

        [Required]
        public string Objetives { get; set; } = string.Empty;

        [Required]
        public string Requirements { get; set; } = string.Empty;
        
        public enum Level 
        {
            Basic,
            Intermediate,
            Advanced
        } 
    }
}

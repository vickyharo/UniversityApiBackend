using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = String.Empty ;
        public DateTime? UpdatedAt { get; set;} = DateTime.Now;
        public string DeleteBy { get; set;} = String.Empty ;
        public DateTime? DeleteAt { get; set; } = DateTime.Now ;
        public bool IsDeleted { get; set; } = false ;

    }
}

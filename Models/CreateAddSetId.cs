using System.ComponentModel.DataAnnotations;

namespace MetaApi.Models
{
   public class CreateAddSetId
    {
        [Key]
        public int PrimaryId { get; set; }
        public string? CategoryName { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool Status { get; set; }
    }
}


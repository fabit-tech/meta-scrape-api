using System.ComponentModel.DataAnnotations;

namespace MetaApi.Models
{
    public partial class Ihale
    {
        [Key]
        public int Id { get; set; }
        public DateTime? RecordDate { get; set; }
        public string ExcelPath {  get; set; }
        public int? CariId  { get; set; }
        public int? IhaleId { get; set; }
        public int? UniqueIndexId { get; set; }
        public string GenelGiderKarYuzdesi { get; set; }
        public bool Status { get; set; }
    }
}

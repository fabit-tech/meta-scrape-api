using System.ComponentModel.DataAnnotations;

namespace MetaApi.Models
{
    public class IhaleBirimFiyat
    {
        [Key]
        public int Id { get; set; }
        public string MalzemeBirimFiyat { get; set; }
        public int IhaleId { get; set; }
    }
}

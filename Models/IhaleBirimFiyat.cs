using System.ComponentModel.DataAnnotations;

namespace MetaApi.Models
{
    public partial class IhaleBirimFiyat
    {
        [Key]
        public int Id { get; set; }
        public int IhaleId {  get; set; }
        public string MalzemeBirimFiyat { get; set; }
    }
}

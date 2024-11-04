using System.ComponentModel.DataAnnotations;

namespace MetaApi.Models
{
    public class IhaleBirimFiyat
    {
        [Key]
        public int Id { get; set; }
        public double MalzemeBirimFiyat { get; set; }
        public int IhaleId { get; set; }
        public string PozNo { get; set; }

        public string ParaBirimi { get; set; }


    }
}

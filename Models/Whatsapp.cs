namespace MetaApi.Models
{
    public partial class Whatsapp
    {
        public string? Name { get; set; }

        public  Int64 Phone { get; set; }

        public string? CustomerId { get; set; }

        public string? Platform { get; set; }

        public string? Message { get; set; }

        public bool? IsIntegrated { get; set; }
        public int? PrimaryKey { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}

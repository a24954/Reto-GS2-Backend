namespace TeatroApi.Models
{
    public class ObraInsertDto
    {
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public string? Duration { get; set; }
        public DateTime? Date { get; set; }

    }
}
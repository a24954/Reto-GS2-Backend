namespace TeatroApi.Models
{
    public class ObraSimpleDto
    {
        public int IdPlay { get; set; }
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public string? Duration { get; set; }

    }
}
namespace Gerenciador_de_estoque.src.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableAmount { get; set; }
        public int AmountChange { get; set; }
    }
}

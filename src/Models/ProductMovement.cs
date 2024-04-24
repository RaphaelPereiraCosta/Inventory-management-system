using System.Collections.Generic;

namespace Gerenciador_de_estoque.src.Models
{
    public class ProductMovement
    {
        public int Id { get; set; }
        public Supplier Supplier = new Supplier();
        public string Type { get; set; }

        public List<Product> ProductsList = new List<Product>();
        public string Date { get; set; }
    }
}

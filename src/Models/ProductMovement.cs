using System;
using System.Collections.Generic;

namespace Gerenciador_de_estoque.src.Models
{
    public class ProductMovement
    {
        public int IdMovement { get; set; }
        public int IdSupplier { get; set; }
        public string Type { get; set; }
        public List<int> ProductsList { get; set; }
        public List<int> Amount { get; set; }
        public string Date { get; set; }

    }
}

﻿namespace Gerenciador_de_estoque.src.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvaliableAmount { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Gerenciador_de_estoque.Models
{
    public class Transacao
    {
        public int IdTransacao { get; set; }
        public List<int> IdProduto { get; set; }
        public string TipoTransacao { get; set; }
        public List<int> Quantidade { get; set; }
        public DateTime DataTransacao { get; set; }
        public double ValorTotal { get; set; }
    }
}

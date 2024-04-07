using System;
using System.Collections.Generic;

namespace Gerenciador_de_estoque.src.Models
{
    public class Movimentacao
    {
        public int IdMovimentacao { get; set; }
        public int idFornecedor { get; set; }
        public List<int> IdProduto { get; set; }
        public string TipoMovimentacao { get; set; }
        public List<int> Quantidade { get; set; }
        public DateTime DataTransacao { get; set; }

    }
}

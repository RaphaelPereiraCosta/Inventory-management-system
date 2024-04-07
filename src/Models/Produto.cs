namespace Gerenciador_de_estoque.src.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}

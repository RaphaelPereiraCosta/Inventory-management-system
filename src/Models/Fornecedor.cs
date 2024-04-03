namespace Gerenciador_de_estoque.Models
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

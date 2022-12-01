using FiaponSmartCity.Models;

namespace FiaponSmartCity.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Caracteristicas { get; set; }
        public double PrecoMedio { get; set; }
        public string Logotipo { get; set; }
        public bool Ativo { get; set; }

        public TipoProduto Tipo { get; set; }
    }
}
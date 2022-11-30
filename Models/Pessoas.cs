using FiaponSmartCity.Models;

namespace FiaponSmartCity.Models
{
    public class Pessoas
    {
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }

        public int Idade { get; set; }  
        public string Endereco { get; set; }


        public TipoPessoa Tipo { get; set; }
    }
}

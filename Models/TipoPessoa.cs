using System.ComponentModel.DataAnnotations;

namespace FiaponSmartCity.Models
{
    public class TipoPessoa
    {
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [StringLength(100)]
        [Display(Name = "Nome:")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório!")]
        [StringLength(50)]
        [Display(Name = "Endereço:")]
        public String Endereco { get; set; }
    }
}

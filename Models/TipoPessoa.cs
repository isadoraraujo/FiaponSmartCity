using System.ComponentModel.DataAnnotations;

namespace FiaponSmartCity.Models
{
    public class TipoPessoa
    {
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória!")]
        [StringLength(50, ErrorMessage = "A descrição deve ter, no máximo, 50 caracteres")]
        [Display(Name = "Descrição:")]
        public String Endereco { get; set; }
        public bool Residente { get; set; }
    }
}

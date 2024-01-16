using System.ComponentModel.DataAnnotations;

namespace Agenda.ViewModels
{
    public class CreateContatoViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo Telefone é obrigatório!")]
        [StringLength(11,MinimumLength = 10, ErrorMessage = "de 10 a 11 carac") ]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo DataNascimento é obrigatório!")]
        public DateTime DataNascimento{ get; set; }

    }
}
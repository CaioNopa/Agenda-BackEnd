namespace Agenda.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
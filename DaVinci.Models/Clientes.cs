using System.ComponentModel.DataAnnotations;

namespace DaVinci.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }

        [Required, StringLength(100)]
        public string? Nome { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        public string? Sexo { get; set; }
        public string? Cidade { get; set; }

        [Required, StringLength(11)]
        public required string Cpf { get; set; }
    }
}
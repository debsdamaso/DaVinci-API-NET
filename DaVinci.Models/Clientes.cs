using System.ComponentModel.DataAnnotations.Schema;

namespace DaVinci.Models
{
    public class Clientes
    {
        public int IdCliente { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Sexo { get; set; }

        public string? Cidade { get; set; }

        public string? Cpf { get; set; }

    }
}
namespace DaVinci.Models
{
    public class Produtos
    {
        public int IdProduto { get; set; }

        public string? Nome { get; set; }

        public decimal Valor { get; set; }

        public string? Categoria { get; set; }

        public string? Modelo { get; set; }

        //1..N
        public int IdCliente { get; set; }
        public Clientes? Cliente { get; set; }

        public ICollection<Feedbacks>? Feedbacks { get; set; }
    }
}
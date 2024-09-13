namespace DaVinci.Models
{
    public class Feedbacks
    {
        public int IdFeedback { get; set; }

        public string? Comentario { get; set; }

        public DateTime DataFeedback { get; set; }

        public int Avaliacao { get; set; }

        //1..1
        public int IdCliente { get; set; }
        public Clientes? Cliente { get; set; }

        //1..1
        public int IdProduto { get; set; }
        public Produtos? Produto { get; set; }
    }
}
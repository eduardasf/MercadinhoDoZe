namespace MercadinhoDoZe.Model
{
    public class Venda
    {
        public DateTime Data { get; set; }

        public Cliente Cliente { get; set; }

        public List<ItemVenda> Items { get; set; }

        public Venda()
        {
            Items = new List<ItemVenda>();
        }
    }
}

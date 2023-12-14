namespace MercadinhoDoZe.Model
{
    public class VendaDAO
    {
        public void Gravar(Venda venda)
        {
            BancoDeDadosFake.vendas.Add(venda);
        }

        public List<Venda> Listar()
        {
            return BancoDeDadosFake.vendas;
        }
    }
}

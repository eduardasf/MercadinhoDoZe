namespace MercadinhoDoZe.Model
{
    public class ProdutoDAO
    {
        public void Gravar(Produto produto)
        {
            BancoDeDadosFake.produtos.Add(produto); 
        }
        
        public List<Produto> Listar()
        {
            return BancoDeDadosFake.produtos;
        }

        public void Excluir(int codigo)
        {
            BancoDeDadosFake.produtos.RemoveAt(codigo);
        }
    }
}

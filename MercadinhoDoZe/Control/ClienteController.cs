using MercadinhoDoZe.Model;

namespace MercadinhoDoZe.Control
{
    public class ClienteController
    {
        private ClienteDAO Dao;

        public ClienteController()
        {
            Dao = new ClienteDAO();
        }

        public void Gravar(Cliente cliente)
        {
            if (cliente.EhValido())
            {
                Dao.Gravar(cliente);
            }
            else
            {
                Console.WriteLine("Dados inválido!");
            }
        }

        public List<Cliente> Listar()
        {
            return Dao.Listar();
        }

        public void Excluir(int codigo)
        {
            Dao.Excluir(codigo);
        }
    }
}

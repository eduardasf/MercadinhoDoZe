using MercadinhoDoZe.Control;
using MercadinhoDoZe.Model;

namespace MercadinhoDoZe.View
{
    public class VendaView
    {
        private VendaController Controller;

        public VendaView()
        {
            Controller = new VendaController();
        }

        public void CriarMenu()
        {
            int opcao = 0;

            do
            {
                string menu = @"
                    ### VENDA ###
                    1- Cadastrar
                    2- Listar
                    9- Voltar ao menu principal
                    Escolhe a opção desejada:
                ";
                Console.Write(menu);

                try
                {
                    opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            Console.Clear();
                            this.Cadastrar();
                            break;
                        case 2:
                            Console.Clear();
                            this.Listar();
                            break;
                        case 9:
                            Console.Clear();
                            MenuView mV = new MenuView();
                            mV.CriarMenuPrincipal();
                            break;
                        default:
                            throw new Exception("Opção selecionada não existe");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida");
                }

            } while (opcao != 9);
        }

        private void Cadastrar()
        {
            Console.WriteLine("### CADASTRAR VENDA ###");

            Console.WriteLine("# Lista de Clientes #");
            var clienteController = new ClienteController();
            var listaClientes = clienteController.Listar();
            for (int i = 0; i < listaClientes.Count; i++)
            {
                Console.WriteLine(String.Format("{0} - {1} ({2})", i, listaClientes[i].Nome, listaClientes[i].Cpf));
            }
            Console.WriteLine("Informe o código do cliente: ");
            int codigoCliente = Int32.Parse(Console.ReadLine());

            Venda venda = new Venda();
            venda.Data = DateTime.Now;
            venda.Cliente = listaClientes[codigoCliente];

            Console.WriteLine();

            Console.WriteLine("# Lista de Produtos #");
            var produtoController = new ProdutoController();
            var listaProdutos = produtoController.Listar();
            for (int i = 0; i < listaProdutos.Count; i++)
            {
                Console.WriteLine(String.Format("{0} - {1} ({2})", i, listaProdutos[i].Descricao, listaProdutos[i].Valor));
            }

            int maisItem = 1;
            while (maisItem == 1)
            {
                Console.WriteLine("Informe o código do produto: ");
                int codigoProduto = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Informe a quantidade: ");
                int quantidade = Int32.Parse(Console.ReadLine());

                ItemVenda item = new ItemVenda();
                item.Produto = listaProdutos[codigoProduto];
                item.Quantidade = quantidade;

                venda.Items.Add(item);

                Console.WriteLine("Deseja informar mais produtos? 1- Sim 2- Não ");
                maisItem = Int32.Parse(Console.ReadLine());
            }

            Controller.Gravar(venda);
            Console.Clear();
        }

        private void Listar()
        {
            Console.WriteLine("### LISTA DE VENDAS ###");
            var lista = Controller.Listar();
            foreach (var v in lista)
            {
                Console.WriteLine("#####################################################");
                Console.WriteLine("Data: " + v.Data.ToString("D"));
                Console.WriteLine(String.Format("Cliente: {0} - {1}", v.Cliente.Cpf, v.Cliente.Nome));
                Console.WriteLine("Itens:");
                foreach (var i in v.Items)
                {
                    Console.WriteLine(String.Format("    {0} - {1} - {2}", i.Produto.Descricao, i.Quantidade, i.Produto.Valor));
                }
                Console.WriteLine("#####################################################");
                Console.WriteLine();
            }
        }
    }
}

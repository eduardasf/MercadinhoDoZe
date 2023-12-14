using MercadinhoDoZe.Control;
using MercadinhoDoZe.Model;

namespace MercadinhoDoZe.View
{
    public class ClienteView
    {
        private ClienteController controller;

        public ClienteView()
        {
            controller = new ClienteController();
        }

        public void CriarMenu()
        {
            int opcao = 0;

            do
            {
                string menu = @"
                    ### CLIENTE ###
                    1- Cadastrar
                    2- Listar
                    3- Excluir
                    9- Voltar ao menu principal
                    Escolhe a opção desejada:
                ";
                Console.Write(menu);

                /*
                 * CRUD
                 *  C- Create Inserir
                 *  R- Read   Ler
                 *  U- Update Alterar
                 *  D- Delete Deletar
                 * */

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
                        case 3:
                            Console.Clear();
                            this.Excluir();
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
            Console.WriteLine("### CADASTRAR CLIENTE ###");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cpf: ");
            string cpf = Console.ReadLine();

            Cliente p = new Cliente();
            p.Nome = nome;
            p.Cpf = cpf;

            ClienteController control = new ClienteController();
            controller.Gravar(p);
        }

        private void Listar()
        {
            Console.WriteLine("### LISTA DE CLIENTES ###");
            var lista = controller.Listar();
            int cont = 0;
            foreach (var p in lista)
            {
                Console.WriteLine(String.Format("{0} - {1} - {2}", cont++, p.Nome, p.Cpf));
            }
        }

        private void Excluir()
        {
            this.Listar();
            Console.WriteLine();
            Console.WriteLine("### EXCLUIR CLIENTE ###");
            Console.WriteLine("Digite o código a ser excluído:");
            int codigo = Int32.Parse(Console.ReadLine());

            controller.Excluir(codigo);
            Console.Clear();
        }
    }
}

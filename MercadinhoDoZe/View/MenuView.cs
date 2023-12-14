namespace MercadinhoDoZe.View
{
    public class MenuView
    {
        public void CriarMenuPrincipal()
        {
            int opcao = 0;

            do
            {
                string menu = @"
                    ### Mercadinho do Zé ###
                    1- Clientes
                    2- Produtos
                    3- Vendas
                    9- Sair
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
                            ClienteView cV = new ClienteView();
                            cV.CriarMenu();
                            break;
                        case 2:
                            Console.Clear();
                            ProdutoView pV = new ProdutoView();
                            pV.CriarMenu();
                            break;
                        case 3:
                            Console.Clear();
                            VendaView vV = new VendaView();
                            vV.CriarMenu();
                            break;
                        case 9:
                            Environment.Exit(0);//Finalizar o programa
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
    }
}

namespace MercadinhoDoZe.Model
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public bool EhValido()
        {
            if (Nome != null && Cpf != null)
            {
                return true;
            }

            return false;
        }
    }
}

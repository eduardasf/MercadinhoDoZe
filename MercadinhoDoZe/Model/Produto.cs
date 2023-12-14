namespace MercadinhoDoZe.Model
{
    public class Produto
    {
        public string Descricao { get; set; }   
        public double Valor { get; set; }

        public bool EhValido()
        {
            if (Descricao != null && Valor != 0)
            {
                return true;
            }

            return false;
        }
    }
}

namespace Cpr.Domain.LivroCaixa
{
    public class Categoria : Entity
    {
        public string CategEntradaSaida { get; private set; }
        
        public Categoria(string categEntradaSaida)
        {
            ValidaSetCatEntradaSaida(categEntradaSaida);
        }

        public void update(string categEntradaSaida)
        {
            ValidaSetCatEntradaSaida(categEntradaSaida);
        }
        private void ValidaSetCatEntradaSaida(string categEntradaSaida)
        {
            DomainException.when(string.IsNullOrEmpty(categEntradaSaida), "nome é requerido");
            DomainException.when(categEntradaSaida.Length < 3, "Nome Inválido");
            CategEntradaSaida = categEntradaSaida;
        }
        
         public void delete(string categEntradaSaida)
        {
            ValidaSetCatEntradaSaida(categEntradaSaida);
        }

    }
}
namespace Cpr.Domain.LivroCaixa
{
    public class ArmazenaCategoria
    {
        private readonly IRepository<Categoria> _categoryRepository;

        public ArmazenaCategoria(IRepository<Categoria> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Armazenar(int id, string categEntradaSaida )
        {
            var categoria = _categoryRepository.GetById(id);
            if(categoria == null)
            {
                categoria = new Categoria(categEntradaSaida);
                _categoryRepository.Save(categoria);
            }
            else
            {
                categoria.update(categEntradaSaida);
            }
            
        }
         public void Deletar(int id)
        {       
            var categoria = _categoryRepository.GetById(id);              
           _categoryRepository.Delete(categoria);
        }
    }
}
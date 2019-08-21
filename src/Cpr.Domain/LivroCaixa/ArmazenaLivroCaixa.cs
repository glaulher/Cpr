using System;

namespace Cpr.Domain.LivroCaixa
{
    public class ArmazenaLivroCaixa
    {
        private readonly IRepository<LivroCaixa> _livroCaixaRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public ArmazenaLivroCaixa(IRepository<LivroCaixa> livroCaixaRepository, IRepository<Categoria> categoriaRepository)
        {
            _livroCaixaRepository = livroCaixaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public void ArmazenarCaixa(int id, bool tipo, int categoriaId, DateTime data, string descricao, decimal valor)
        {
            var categoria = _categoriaRepository.GetById(categoriaId);
            DomainException.when(categoria == null, "Categoria invalida");

            var livroCaixa = _livroCaixaRepository.GetById(id);
            if(livroCaixa == null)
            {
                livroCaixa = new LivroCaixa(tipo, categoria, data, descricao, valor);
                _livroCaixaRepository.Save(livroCaixa);
            }
            else
                livroCaixa.Update(tipo, categoria, data, descricao, valor);;
        }
    
         public void Deletar(int id)
        {       
            var livroCaixa = _categoriaRepository.GetById(id);              
           _categoriaRepository.Delete(livroCaixa);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Cpr.Web.ViewsModels;
using Cpr.Domain;
using Cpr.Domain.LivroCaixa;

namespace Cpr.Web.Components
{
    public class LivroCaixaList : ViewComponent
    {
        private readonly ArmazenaLivroCaixa _armazenaLivroCaixa ;
        private readonly IRepository<LivroCaixa> _livroCaixaRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public LivroCaixaList(ArmazenaLivroCaixa armazenaLivroCaixa,
            IRepository<LivroCaixa> livroCaixaRepository,
            IRepository<Categoria> categoriaRepository)
        {
            _armazenaLivroCaixa = armazenaLivroCaixa;
            _livroCaixaRepository = livroCaixaRepository;
            _categoriaRepository = categoriaRepository;
        }
        public IViewComponentResult Invoke()
        {

          
            var livroCaixa = _livroCaixaRepository.All(); 
            if(livroCaixa.Any())
            {    
                var viewsModels = livroCaixa.Select(l => new LivroCaixaViewModel{ Id = l.Id, Tipo = l.Tipo,
                    CategoriaName = l.Categoria.CategEntradaSaida,
                    Data = l.Data, Descricao = l.Descricao, Valor = l.Valor});
                return View(viewsModels);
            }
            return View();
        }
    }    
}
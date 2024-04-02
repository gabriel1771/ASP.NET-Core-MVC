using LanchesMac2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac2.Componentes
{
    public class CategoriaMenu :ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        
        public IViewComponentResult Invoke()
        {
            var categoria = _categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categoria);
        }
    }
}

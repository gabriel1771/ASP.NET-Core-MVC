using LanchesMac2.Repositories.Interfaces;
using LanchesMac2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac2.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchesRepository _lancheRepository;

        public LancheController(ILanchesRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            /*---------------------------------------------*/

            //var lanches = _lancheRepository.Lanches;

            ////esse aqui eu posso criar em qualquer controller e posso usar
            ////ou chamar em qualquer views, porem ele so retorna uma vez o valor
            ////ou seja no primeiro request, se for atualizado a pagina por exemplo
            ////já não vai ter mais o valor
            //TempData["Nome"] = "Gabriel";

            ////aqui eu to criando 2 ViewBag que no caso vou poder usar 
            ////na view como fonte de dados tambem
            //var totalLanches = lanches.Count();
            //ViewBag.Total = "Total de lanches: ";
            //ViewBag.TotalLanches = totalLanches;

            ////aqui eu to definindo o dicionarios e seus valores 
            ////que serão acessados como fonte de dados na views que este 
            ////controlador está criando
            //ViewData["Titulo"] = "Todos os Lanches";
            //ViewData["Data"] = DateTime.Now;


            ////aqui eu to retornando um modelo, que é um TIPO que neste caso
            ////eu defini como um IEnumerable <Lanche> (uma lista do tipo Lanches)
            //// mas poderia ser qualquer coisa, ou uma estrutura maior ou menor
            //// de dados, pois isso vai ser uma das principais coisas, utilizadas
            //// na construção das views

            /*---------------------------------------------*/

            //var lanches = _lancheRepository.Lanches;
            //return View(lanches);
            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lanchesListViewModel);
        }
    }
}

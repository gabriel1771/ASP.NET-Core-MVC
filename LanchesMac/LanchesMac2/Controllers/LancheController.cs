using LanchesMac2.Models;
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

        //um poderoso metodo IActionResult que retorna 3 possiveis listas diferentes
        public IActionResult List(string categoria)
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
            //var lanchesListViewModel = new LancheListViewModel();
            //lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            //lanchesListViewModel.CategoriaAtual = "Categoria Atual";


            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            //verificando se o argumento da actions é null ou vazio
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lacnhes";
            }
            else
            {
                //if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRepository.Lanches
                //                               .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                //                               .OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _lancheRepository.Lanches
                //                               .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                //                               .OrderBy(l => l.Nome);
                //}

                lanches = _lancheRepository.Lanches
                          .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                          .OrderBy(c => c.Nome);
            }

            categoriaAtual = categoria;

            LancheListViewModel lanchesListViewModel = new()
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };


            return View(lanchesListViewModel);
        }

        //retorna apenas os dados da quele lanche especifico
        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }
        

    }
}

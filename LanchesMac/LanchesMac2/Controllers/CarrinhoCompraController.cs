using LanchesMac2.Models;
using LanchesMac2.Repositories;
using LanchesMac2.Repositories.Interfaces;
using LanchesMac2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac2.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILanchesRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        //aqui acontece o que descrevi no arquivo startup
        public CarrinhoCompraController(ILanchesRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        //metodo que cria view do carrinho de compra e retorna os itens no mesmo
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            //essa linha é desnecessaria
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVm = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVm);
        }

        //metodo que adiciona itens ao carrinho e que conversa com a view 
        public IActionResult AdicionarItemCarrinhoCompra(int lancheId)
        {
                             
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            
            if(lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }

        //metodo que conversa com a view que remove itens ao carrinho
        public IActionResult RemoverItemCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }

    }
}

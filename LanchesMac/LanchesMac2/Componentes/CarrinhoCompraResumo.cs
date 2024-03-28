using LanchesMac2.Models;
using LanchesMac2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac2.Componentes
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        //aqui eu chamo aquele metodo static da class CarrinhoCompra
        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            //var itens = new List<CarrinhoCompraItem>()
            //{
            //    new CarrinhoCompraItem(),
            //    new CarrinhoCompraItem()
            //};

            //essa linha é desnecessaria!!
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVm = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVm);
        }

        
    }
}

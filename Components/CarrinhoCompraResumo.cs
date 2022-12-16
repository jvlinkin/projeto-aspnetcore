using LanchesJa.Models;
using LanchesJa.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesJa.Components
{
	public class CarrinhoCompraResumo : ViewComponent
	{
		private readonly CarrinhoCompra _carrinhoCompra;

		public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
		{
			_carrinhoCompra= carrinhoCompra;
		}
		public IViewComponentResult Invoke()
		{
			//Recuperando os itens do carrinho
			var itens = _carrinhoCompra.GetCarrinhoCompraItens();

			//var itens = new List<CarrinhoCompraItem>()
			//{
			//	new CarrinhoCompraItem(),
			//	new CarrinhoCompraItem()
			//};	

			//Jogando os itens recuperados, para dentro dos itens do carrinho;
			_carrinhoCompra.CarrinhoCompraItems = itens;

			var carrinhoCompraViewModel = new CarrinhoCompraViewModel
			{
				CarrinhoCompra = _carrinhoCompra,
				CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
			};
			return View(carrinhoCompraViewModel);
		}
	}
}

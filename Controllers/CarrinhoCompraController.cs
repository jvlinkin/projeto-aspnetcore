using LanchesJa.Models;
using LanchesJa.Repositories.Interfaces;
using LanchesJa.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesJa.Controllers
{
	public class CarrinhoCompraController : Controller
	{
		private readonly ILancheRepository _lancheRepository;
		private readonly CarrinhoCompra _carrinhoCompra;

		public CarrinhoCompraController(ILancheRepository lancheRepository,
										CarrinhoCompra carrinhoCompra)
		{
			_lancheRepository = lancheRepository;
			_carrinhoCompra = carrinhoCompra;
		}

		//Método para gerar carrinho de compras.
		public IActionResult Index()
		{
			//Recupernado os itens do carrinho
			var itens = _carrinhoCompra.GetCarrinhoCompraItens();

			//Jogando os itens recuperados, para dentro dos itens do carrinho;
			_carrinhoCompra.CarrinhoCompraItems = itens;

			var carrinhoCompraVM = new CarrinhoCompraViewModel
			{
				CarrinhoCompra = _carrinhoCompra,
				CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
			};
			return View(carrinhoCompraVM);
		}
		public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
		{
			var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p=>p.LancheId == lancheId);

			if(lancheSelecionado != null)
			{
				_carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
			}
			return RedirectToAction("Index");
		}

		public IActionResult RemoverItemDoCarrinhoDeCompra(int lancheId)
		{
			var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(l=>l.LancheId == lancheId);

			if(lancheSelecionado != null )
			{
				_carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
			}
			return RedirectToAction("Index");
		}
	}
}

using LanchesJa.Models;
using LanchesJa.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesJa.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepositorio pedidoRepositorio,
                                 CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _carrinhoCompra = carrinhoCompra;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            return View();
        }

    }
}

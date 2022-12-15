using LanchesJa.Context;
using LanchesJa.Migrations;
using Microsoft.EntityFrameworkCore;

namespace LanchesJa.Models
{
	public class CarrinhoCompra
	{
		private readonly AppDbContext _context;

		public CarrinhoCompra(AppDbContext context)
		{
			_context = context;
		}

		public string CarrinhoCompraId { get; set; }
		public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

		//Métodos
		//Nesse caso não foi utilizado o método Repository
		public static CarrinhoCompra GetCarrinho(IServiceProvider services)
		{
			//define uma sessão
			ISession session =  services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

			//obtem um serviço do tipo do nosso contexto
			var context = services.GetService<AppDbContext>();

			//obtem ou gera o id do carrinho
			string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

			//atribui o id do carrinho na sessão
			session.SetString("CarrinhoId", carrinhoId);

			//retorna o carrinho com o contexo e o Id atribuido ou obtido
			return new CarrinhoCompra(context)
			{
				CarrinhoCompraId = carrinhoId
			};
		}

		public void AdicionarAoCarrinho(Lanche lanche)
		{
			var carrinhoCompraItem = _context.CarrinhoCompraItens
				//verificando se existe um lanche com o id que o usuario passou,
				//e verificando se existe um carrinho de compra.
				.SingleOrDefault(s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

			if(carrinhoCompraItem == null)
			{
				carrinhoCompraItem = new CarrinhoCompraItem
				{
					CarrinhoCompraId = CarrinhoCompraId,
					Lanche = lanche,
					Quantidade = 1
				};

				_context.CarrinhoCompraItens.Add(carrinhoCompraItem);
			}
			else
			{
				//Caso já exista o item no carrinho, só incremente a quantidade em +1.
				carrinhoCompraItem.Quantidade++;
			}
			_context.SaveChanges();

		}
		public void RemoverDoCarrinho(Lanche lanche)
		{
			var carrinhoCompraItem = _context.CarrinhoCompraItens
				.SingleOrDefault(s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

			

			if(carrinhoCompraItem!= null)
			{
				if(carrinhoCompraItem.Quantidade > 1)
				{
					carrinhoCompraItem.Quantidade--;					
				}
				else
				{
					_context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
				}
			}
			_context.SaveChanges();
			
		}

		public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
		{
			return CarrinhoCompraItems ??
				(CarrinhoCompraItems = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
				.Include(s => s.Lanche)
				.ToList());
		}

		public void LimparCarrinho()
		{
			var carrinhoItens = _context.CarrinhoCompraItens
				.Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

			_context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
			_context.SaveChanges();
		}

		public decimal GetCarrinhoCompraTotal()
		{
			var total = _context.CarrinhoCompraItens
				.Where(c=>c.CarrinhoCompraId==CarrinhoCompraId)
				.Select(c=>c.Lanche.Preco * c.Quantidade).Sum();

			return total;
		}
	}
}

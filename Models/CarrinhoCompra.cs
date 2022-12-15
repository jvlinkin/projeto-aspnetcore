using LanchesJa.Context;
using LanchesJa.Migrations;

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
	}
}

using LanchesJa.Models;
using LanchesJa.Repositories.Interfaces;
using LanchesJa.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesJa.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;            
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                //OrdinalIgnoreCase ignora o case-sensitive e tanto faz letras maiúsculas ou minúsculas.
                if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.Nome);
					categoriaAtual = "Normal";
                }
                else if (string.Equals("Natural", categoria, StringComparison.OrdinalIgnoreCase))
				{
					lanches = _lancheRepository.Lanches
						.Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
						.OrderBy(l => l.Nome);

					categoriaAtual = "Natural";
				}
                else
                {
					return View("LancheNaoExiste");
				}

            }
            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches= lanches,
                CategoriaAtual = categoriaAtual
            };


			


			return View(lanchesListViewModel);
        }
    }
}

using LanchesJa.Models;
using LanchesJa.Repositories.Interfaces;
using LanchesJa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
                lanches = _lancheRepository.Lanches
                    .Where(c=>c.Categoria.CategoriaNome
                    .Equals(categoria)).OrderBy(c=>c.Nome);
                categoriaAtual = categoria;

            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches= lanches,
                CategoriaAtual = categoriaAtual
            };		


			return View(lanchesListViewModel);
        }

        public IActionResult Details (int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l=>l.LancheId == lancheId);
            return View(lanche);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(c => c.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));



                if(lanches.Any())
                {
                    categoriaAtual = $"Lanches que contém a palavra: {searchString} ";

                }
                else
                {
                    categoriaAtual = "Nenhum lanche foi encontrado";
                };

            }
            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                CategoriaAtual = categoriaAtual,
                Lanches = lanches
            });
        }
    }
}

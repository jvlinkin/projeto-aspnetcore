using LanchesJa.Context;
using LanchesJa.Models;
using LanchesJa.Repositories.Interfaces;

namespace LanchesJa.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

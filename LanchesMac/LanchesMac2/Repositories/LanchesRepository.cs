using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LanchesRepository : ILanchesRepository
    {

        private readonly AppDbContext _context;

        //aqui eu to uzando um serviço do meu projeto que 
        //vai retornar uma instancia de um objeto do tipo appDbContext
        public LanchesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);
        //public IEnumerable<Lanche> Lanches()
        //{
        //    return _context.Lanches.Include(c => c.Categoria);
        //}

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
                                   Where(l => l.IsLanchePreferido).Include(c => c.Categoria);



        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}

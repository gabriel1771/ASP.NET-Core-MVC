using LanchesMac2.Context;
using LanchesMac2.Models;
using LanchesMac2.Repositories.Interfaces;

namespace LanchesMac2.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        //criando um campo que precisa ser atribuido no construtor apenas(ou seja não da pra alterar mais dai)
        //e esse campo em especifico é do tipo AppDbContext que é a classe que eu criei para poder relacionar
        //as tabelas ao banco de dados pelo EEF
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

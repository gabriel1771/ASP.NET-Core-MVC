using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        //definindo um contrato
        IEnumerable<Categoria> Categorias { get; }
    }
}

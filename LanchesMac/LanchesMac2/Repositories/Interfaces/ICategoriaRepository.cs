using LanchesMac2.Models;

namespace LanchesMac2.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        //definindo um contrato
        IEnumerable<Categoria> Categorias { get; }
    }
}

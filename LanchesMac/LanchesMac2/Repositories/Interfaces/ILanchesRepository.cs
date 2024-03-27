using LanchesMac2.Models;

namespace LanchesMac2.Repositories.Interfaces
{
    public interface ILanchesRepository
    {
        IEnumerable<Lanche> Lanches {get;}
        IEnumerable<Lanche> LanchesPreferidos {get;}

        Lanche GetLancheById(int lancheId);
    }
}

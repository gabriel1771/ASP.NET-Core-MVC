using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{ 
    //herdando uma classe da framework EntityFrameworkCore
    public class AppDbContext : DbContext
    {

        //aqui eu crio um metodo contrutor que vai ter como parâmetro o argumento
        //options que vai ser do tipo DbContexOptions<AppDbContext> que é uma classe
        //generica do framework, e então esse argumento eu passo para o construtor 
        //da classe base que é o DbContext
        //E por fim esse argumento contem as configurações necessarias configuras o 
        //banco de dados ...
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        //aqui estou criando propiedades do tipo generico DbSet que compões o 
        //placeholder Categoria qúe é minha outra classe com outras propiedades
        //ou seja, com isso A DbContext consegue criar as tabelas e colunas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
    }
}

using LanchesMac2.Context;
using LanchesMac2.Repositories.Interfaces;

using LanchesMac2.Repositories;

using LanchesMac2.Repositories;
using LanchesMac2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using LanchesMac2.Models;

namespace LanchesMac2;

public class Startup
{
    public IConfiguration Configuration { get; }


    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }



    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        //aqui eu to adicionando o serviço de banco de dados usando o EEF que usa a classe AppDbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        //aqui eu estou adicionando o serviço MVC que são as rotas que é o backend praticamente da aplicação
        services.AddControllersWithViews();

        //aqui vou criar um serviço que vai criar uma instancia automaticamente cada vez que eu usar essas classes e vou poder usar em qualquer parte do projeto 
        //somente chamando a classe
        services.AddTransient<ILanchesRepository, LanchesRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();

        //adicionando o serviço que nos permite acessar os recursos do httpContext
        //que é as ferramentas das requisições
        //e esse serviço vai valer por todo o tempo de vida da aplicação
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //aqui eu to criando um serviço normal igual todos os outros, porem
        //ao chamar essa instancia gerada automaticamente pela injeção de dependenciaas
        //eu já estou chamando o metodo statico da classe e então já estou criando ou 
        //identificando uma sessão juntamente com a criação ou identificação de um carrinho de compras
        // e também alem dessas caracteristicas, esse serviço é chamado
        //a cada request, ou seja, vai gerar uma instancia diferente pra cada 
        //cliente
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

       

        //habilitando o cache da memoria 
        services.AddMemoryCache();
        //habilitando o session
        services.AddSession(); 

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        //ativando o session
        app.UseSession();

        app.UseAuthorization();

        //criando novas rotas
        app.UseEndpoints(endpoints =>
        {
     
            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Lanche/{action}/{categoria?}",
                defaults: new { controller = "Lanche", action = "List" });

            //essa é a rota padrão a ser chamada
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            

        });
    }
}

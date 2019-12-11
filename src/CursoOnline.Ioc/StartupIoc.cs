using System;
using CursoOnline.Dados.Contexto;
using CursoOnline.Dados.Repositorio;
using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Curso;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;





namespace CursoOnline.Ioc
{
    public static class StartupIoc
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=CursoOnline;User ID=sa;Password=MyPassword001"));

                services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
                services.AddScoped( typeof(ICursoRepositorio), typeof(CursoRepositorio));
                services.AddScoped( typeof(IUnitOfWorks), typeof(UnitOfWorks));
                services.AddScoped<ArmazenadorDeCurso>();                

        }
    }
}

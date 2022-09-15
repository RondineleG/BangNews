using BangNews.Api.Data;
using BangNews.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BangNews.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var environment = builder.Environment;

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            builder.Services.AddDbContext<BangNewsApiContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<NoticiaServices, NoticiaServices>();
            builder.Services.AddTransient<AutorServices, AutorServices>();
            builder.Services.AddMvc();
            builder.Services.AddCors(opciones =>
            {
                opciones.AddPolicy("PermitirTodo", acceso => acceso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            var app = builder.Build();
            app.UseCors("PermitirTodo");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
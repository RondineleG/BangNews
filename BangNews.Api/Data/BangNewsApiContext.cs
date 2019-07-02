using BangNews.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BangNews.Api.Data
{
    public class BangNewsApiContext : DbContext
    {
        public BangNewsApiContext(DbContextOptions<BangNewsApiContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Noticia> Noticias { get; set; }
        public virtual DbSet<Nome> Nomes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new Noticia.Map(modelB.Entity<Noticia>());
            new Autor.Map(modelB.Entity<Autor>());
            base.OnModelCreating(modelB);
        }
    }
}

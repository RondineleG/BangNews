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
        public virtual DbSet<Noticia> Noticia { get; set; }
        public virtual DbSet<Nomes> Nombres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new Noticia.Map(modelB.Entity<Noticia>());
            new Autor.Map(modelB.Entity<Autor>());
            base.OnModelCreating(modelB);
        }
    }
}

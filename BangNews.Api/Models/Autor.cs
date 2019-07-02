using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BangNews.Api.Models
{
    public class Autor
    {
        public int AutorID { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public List<Noticia> Noticias { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Autor> mapAutor)
            {
                mapAutor.HasKey(x => x.AutorID);
                mapAutor.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(50);
                mapAutor.Property(x => x.Apelido).HasColumnName("Apelido").HasMaxLength(50);
            }
        }
    }
}

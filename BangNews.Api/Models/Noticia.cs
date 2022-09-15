using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace BangNews.Api.Models
{
    public class Noticia
    {
        public int NoticiaID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int AutorID { get; set; }
        public Autor Autor { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Noticia> mapNoticia)
            {
                mapNoticia.HasKey(x => x.NoticiaID);
                mapNoticia.Property(x => x.Titulo).HasColumnName("Titulo").HasMaxLength(50);
                mapNoticia.Property(x => x.Descricao).HasColumnName("Descricao").HasMaxLength(100);
                mapNoticia.Property(x => x.Conteudo).HasColumnName("Conteudo").HasMaxLength(int.MaxValue);
                mapNoticia.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("Datetime");
                mapNoticia.Property(x => x.AutorID).HasColumnName("AutorID").HasColumnType("int");
                mapNoticia.HasOne(x => x.Autor);

            }
        }
    }
}

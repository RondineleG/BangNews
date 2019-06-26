using System.ComponentModel.DataAnnotations;

namespace BangNews.Api.Models
{
    public class Nomes
    {
 
            [Key]
            public int NombreID { get; set; }
            public string Nombre { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace BangNews.Api.Models
{
    public class Nome
    {

        [Key]
        public int NomeID { get; set; }
        public string Nomes { get; set; }

    }
}

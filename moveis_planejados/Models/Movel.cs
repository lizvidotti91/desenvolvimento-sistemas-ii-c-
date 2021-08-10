using System.ComponentModel.DataAnnotations;

namespace moveis_planejados.Models
{
    public class Movel
    {
        [Key]
        public int MovelId { get; set; }
        
        public string Nome { get; set; }
        public string Cor { get; set; }

        [Display(Name="Dimensões em metros")]
        public string Medidas { get; set; }
        
        public string Material { get; set; }

        [Display(Description="URL da imagem do móvel")]
        public string Imagem { get; set; }
    }
}
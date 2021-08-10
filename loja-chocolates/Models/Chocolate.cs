using System;
using System.ComponentModel.DataAnnotations;

namespace loja_chocolates.Models
{
    public class Chocolate
    {
        public int ChocolateId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        public int PorcentagemCacau { get; set; }
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        public DateTime DataValidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        public float Preco { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace moveis_planejados.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public float Valor { get; set; }

        [Display(Name="Status")]
        public string StatusVenda { get; set; }

        [Display(Name="Móvel")]
        public int MovelId { get; set; }
        public virtual Movel Movel { get; set; }

        [Display(Name="Funcionário")]
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario {get; set;}
    }
}
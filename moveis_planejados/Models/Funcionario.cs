using System.ComponentModel.DataAnnotations;

namespace moveis_planejados.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }

        public string Nome { get; set; }

        [Display(Name="Status", Description="Status do Funcionário")]
        public string StatusFuncionario { get; set; }
    }
}
using System.Collections.Generic;

namespace moveis_planejados.Models
{
    public class Services
    {
        public static List<StatusFuncionario> getStatusFuncionario()
        {
            var listaStatus = new List<StatusFuncionario>()
            {
                new StatusFuncionario(){ StatusValue = "Disponível", Status= "Disponível"},
                new StatusFuncionario(){ StatusValue = "Indisponível", Status= "Indisponível"}
            };
            return listaStatus;
        }

        public static List<StatusVenda> getStatusVenda()
        {
            var listaStatus = new List<StatusVenda>()
            {
                new StatusVenda(){ StatusValue = "Solicitado", Status = "Solicitado"},
                new StatusVenda(){ StatusValue = "Em construção", Status = "Em construção"},
                new StatusVenda(){ StatusValue = "Entregue", Status = "Entregue"}
            };
            return listaStatus;
        }
    }
}
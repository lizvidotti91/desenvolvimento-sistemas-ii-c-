using System;

namespace sistema_registro_hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Campanha campanha1 = new Campanha();
            campanha1.Nome = "Campanha SSA";
            campanha1.Endereco = "Rua da Campanha";
            campanha1.QuantFuncionarios = 10;
            campanha1.QuantLeitos = 10;
            campanha1.QuantRespiradores = 10;
            campanha1.SalarioMedio = 5;

            float custosCampanha = campanha1.Custos();

            UPA upa1 = new UPA();
            upa1.Nome = "UPA SSA";
            upa1.Endereco = "Rua da UPA";
            upa1.QuantAmbulancias = 10;
            upa1.QuantFuncionarios = 10;
            upa1.QuantLeitos = 10;
            upa1.SalarioMedio = 5;

            float custosUPA = upa1.Custos();

            Console.WriteLine("O Hospital " + campanha1.Nome + " gastou R$ " + custosCampanha);
            Console.WriteLine("A UPA " + upa1.Nome + " gastou R$ " + custosUPA);
        }
    }
}

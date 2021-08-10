namespace sistema_registro_hospital
{
    public class UPA: Hospital
    {
        public int QuantAmbulancias { get; set; }
        public override float Custos(){
            return (QuantFuncionarios + QuantAmbulancias) * SalarioMedio;
        }
    }
}
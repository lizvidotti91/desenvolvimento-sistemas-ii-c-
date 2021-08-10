namespace sistema_registro_hospital
{
    public class Hospital
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int QuantLeitos { get; set; }
        public int QuantFuncionarios { get; set; }
        public float SalarioMedio { get; set; }
        public virtual float Custos(){
            return SalarioMedio * QuantFuncionarios;
        }
    }
}
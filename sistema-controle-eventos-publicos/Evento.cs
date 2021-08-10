using System.Collections.Generic;

namespace sistema_controle_eventos_publicos
{
    public class Evento
    {
        public string Nome { get; set; }
        public string Local { get; set; }
        private float valor;
        public float Valor { get;}
        public bool Gratuito { get; set; }
        public ICollection<Pessoa> Pessoas { get;}
        public Evento(){
            this.Pessoas = new List<Pessoa>();
        }
        public bool AddPessoa(Pessoa pessoa){
            if(Pessoas.Count < 2){
                Pessoas.Add(pessoa);
                return true;
            }
            return false;
        }

        public void AddValor(float valor = 0){
            if(Gratuito){
                this.valor = 0f;
            } else {
                this.valor = valor;
            }
        }
    }
}
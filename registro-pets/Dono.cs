using System.Collections.Generic;

namespace registro_pets
{
    public class Dono
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }

        public List<Pet> Lista { get; set; }
    }
}
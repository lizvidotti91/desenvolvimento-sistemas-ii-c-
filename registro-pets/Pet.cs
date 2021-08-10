namespace registro_pets
{
    public class Pet
    {
        public string Nome { get; set; }
        public string Raca { get; set; }
        public bool Vacinado { get; set; }
        public int Idade { get; set; }

        public Dono Dono { get; set; }
    }
}
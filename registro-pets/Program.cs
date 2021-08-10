using System;
using System.Collections.Generic;

namespace registro_pets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciando objeto monica, pertence à classe Dono
            Dono monica = new Dono();
            monica.Nome = "Mônica";
            monica.Idade = 7;
            monica.Endereco = "Rua do Limoeiro, N. 13";

            // INstanciando objeto magali, pertence à classe Dono
            Dono magali = new Dono();
            magali.Nome = "Magali";
            magali.Idade = 7;
            magali.Endereco = "Rua do Limoeiro, N. 15";

            // Instanciando os Pets e atribuindo um dono para cada um
            Cachorro monicao = new Cachorro();
            monicao.Nome = "Monicão";
            monicao.Idade = 3;
            monicao.Raca = "King charles spaniel";
            monicao.Porte = "Pequeno";
            monicao.Vacinado = true;
            monicao.Dono = monica;

            Cachorro floquinho = new Cachorro();
            floquinho.Nome = "Floquinho";
            floquinho.Idade = 2;
            floquinho.Raca = "lhasa apso";
            floquinho.Porte = "Médio";
            floquinho.Vacinado = true;
            floquinho.Dono = monica;

            // Atribuindo uma lista de Pets para o objeto monica
            List<Pet> petsDaMonica = new List<Pet>();
            petsDaMonica.Add(monicao);
            petsDaMonica.Add(floquinho);

            monica.Lista = petsDaMonica;

            // Instanciando os Pets e atribuindo um dono para cada um
            Gato mingau = new Gato();
            mingau.Nome = "Mingau";
            mingau.Idade = 4;
            mingau.Raca = "Angorá";
            mingau.Vacinado = false;
            mingau.Dono = magali;

            Cachorro bidu = new Cachorro();
            bidu.Nome = "Bidu";
            bidu.Idade = 5;
            bidu.Raca = "Scottish Terrier";
            bidu.Porte = "Pequeno";
            bidu.Vacinado = true;
            bidu.Dono = magali;

            // Atribuindo uma lista de Pets para o objeto magali
            List<Pet> petsDaMagali = new List<Pet>();
            petsDaMagali.Add(mingau);
            petsDaMagali.Add(bidu);

            magali.Lista = petsDaMagali;

            Console.WriteLine(monica.Nome + " possui " + monica.Lista.Count + " pets");
            foreach(Pet pet in monica.Lista){
                Console.WriteLine("- " + pet.Nome + " é um(a) " + pet.Raca + " de " + pet.Idade + " anos ");
            }

            Console.WriteLine(magali.Nome + " possui " + magali.Lista.Count + " pets");
            foreach(Pet pet in magali.Lista){
                Console.WriteLine("- " + pet.Nome + " é um(a) " + pet.Raca + " de " + pet.Idade + " anos ");
            }
        }
    }
}

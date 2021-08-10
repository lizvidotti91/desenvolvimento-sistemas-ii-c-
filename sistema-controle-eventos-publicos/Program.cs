using System;

namespace sistema_controle_eventos_publicos
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa p1 = new Pessoa();
            p1.Nome = "Mônica";
            p1.Idade = 7;
            p1.Endereco = "Rua do Limoeiro, 01";

            Pessoa p2 = new Pessoa();
            p2.Nome = "Cebolinha";
            p2.Idade = 7;
            p2.Endereco = "Rua do Limoeiro, 10";

            Pessoa p3 = new Pessoa();
            p3.Nome = "Magali";
            p3.Idade = 7;
            p3.Endereco = "Rua do Limoeiro, 06";

            Evento evento = new Evento();
            evento.Nome = "Concurso Dono da Rua";
            evento.Local = "Pracinha do Limoeiro";
            evento.Gratuito = true;
            evento.AddValor(1);

            Console.WriteLine("O evento " + evento.Nome + " custa $" + evento.Valor);

            if(evento.AddPessoa(p1)){
                Console.WriteLine(p1.Nome + " foi inserido no evento " + evento.Nome + " com sucesso!");
            } else {
                Console.WriteLine("Evento Lotado! Não foi possível inseririr " + p1.Nome);
            }

            if(evento.AddPessoa(p2)){
                Console.WriteLine(p2.Nome + " foi inserido no evento " + evento.Nome + " com sucesso!");
            } else {
                Console.WriteLine("Evento Lotado! Não foi possível inseririr " + p2.Nome);
            }

            if(evento.AddPessoa(p3)){
                Console.WriteLine(p3.Nome + " foi inserido no evento " + evento.Nome + " com sucesso!");
            } else {
                Console.WriteLine("Evento " + evento.Nome + " Lotado! Não foi possível inserir " + p3.Nome);
            }
        }
    }
}

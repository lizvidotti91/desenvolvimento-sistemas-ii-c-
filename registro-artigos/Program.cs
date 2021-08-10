using System;
using System.Collections.Generic;

namespace registro_artigos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciando autores do primeiro artigo
            Autor autor1 = new Autor();
            autor1.Nome = "Alves, Lynn Rosalina Gama";
            autor1.Email = "alves@exemplo.com.br";

            Autor autor2 = new Autor();
            autor2.Nome = "Minho, Marcelle Rose da Silva";
            autor2.Email = "minho@exemplo.com.br";

            Autor autor3 = new Autor();
            autor3.Nome = "Diniz, Marcelo Vera Cruz";
            autor3.Email = "diniz@exemplo.com.br";

            // Adicionando autores numa lista
            List<Autor> listaAutores1 = new List<Autor>();
            listaAutores1.Add(autor1);
            listaAutores1.Add(autor2);
            listaAutores1.Add(autor3);

            // Adicionando palavras chave numa lista
            List<string> palavrasChave1 = new List<string>();
            palavrasChave1.Add("gamificação");
            palavrasChave1.Add("aprendizagem");

            // Instanciando um artigo
            Artigo art1 = new Artigo();
            art1.Titulo = "Gamificação: diálogos com a educação";
            art1.Instituicao = "SENAI CIMATEC";
            art1.Autores = listaAutores1;
            art1.PalavrasChave = palavrasChave1;

            // Instanciando autores do segundo artigo
            Autor autor4 = new Autor();
            autor4.Nome = "Monteiro, Roberto";
            autor4.Email = "monteiro@exemplo.com.br";

            Autor autor5 = new Autor();
            autor5.Nome = "Diniz, Marcelo Vera Cruz";
            autor5.Email = "diniz@exemplo.com.br";

            Autor autor6 = new Autor();
            autor6.Nome = "Borges, Hernane";
            autor6.Email = "borges@exemplo.com.br";

            // Lista de Autores
            List<Autor> listaAutores2 = new List<Autor>();
            listaAutores2.Add(autor4);
            listaAutores2.Add(autor5);
            listaAutores2.Add(autor6);

            // Lista de Palavras Chave
            List<string> palavrasChave2 = new List<string>();
            palavrasChave2.Add("gamificação");
            palavrasChave2.Add("ensino médio");
            palavrasChave2.Add("realidade aumentada");
            palavrasChave2.Add("objeto de aprendizagem");

            // Instanciando artigo
            Artigo art2 = new Artigo();
            art2.Titulo = "A realidade aumentada e a gamificação aplicadas no ensino de ciências.";
            art2.Instituicao = "SENAI CIMATEC";
            art2.Autores = listaAutores2;
            art2.PalavrasChave = palavrasChave2;
            
            // Lista com todos os artigos
            List<Artigo> todosArtigos = new List<Artigo>();
            todosArtigos.Add(art1);
            todosArtigos.Add(art2);

            // Instanciando novo repositório
            Repositorio cimatec = new Repositorio();
            cimatec.Artigos = todosArtigos;

            Console.WriteLine("Digite uma palavra chave para a busca de artigos:");
            string busca = Console.ReadLine();

            List<Artigo> Resposta = cimatec.ArtigosPorPalavraChave(busca);
            
            if(Resposta != null)
            {
                foreach(Artigo artigo in Resposta){
                    Console.WriteLine("Título: " + artigo.Titulo);

                    Console.Write("Autores: ");
                    foreach(Autor autor in artigo.Autores){
                        Console.Write(autor.Nome + "; ");
                    }
                }
            } 
            else
            {
                Console.WriteLine("Não foram encontrados resultados em sua busca!");
            }
        }
    }
}

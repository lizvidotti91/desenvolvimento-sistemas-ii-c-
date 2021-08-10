using System.Collections.Generic;

namespace registro_artigos
{
    public class Repositorio
    {
        public ICollection<Artigo> Artigos { get; set; }
        public List<Artigo> ArtigosPorPalavraChave(string palavraChave){
            List<Artigo> artigosComPalavraChave = new List<Artigo>();

            foreach (Artigo artigo in Artigos)
            {
                if(artigo.PalavrasChave.Exists(item => item == palavraChave)){
                    artigosComPalavraChave.Add(artigo);
                }
            }
            return artigosComPalavraChave;
        }
    }
}
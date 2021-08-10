using System.Collections.Generic;

namespace registro_artigos
{
    public class Artigo
    {
        public string Titulo { get; set; }
        public string Instituicao { get; set; }
        public List<string> PalavrasChave { get; set; }
        // para importação de bibliotecas, usar o crtl + .
        public ICollection<Autor> Autores { get; set; }
        // o IColletion é útil para o mapeamento no Banco de Dados
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using formularios_razor.Models;

namespace formularios_razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Exercicio1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Exercicio1 (string nome, string sobrenome, string nascimento, string usuario, string senha, string confirma ){
            if(ModelState.IsValid){
                TempData["nome"] = nome;
                TempData["sobrenome"] = sobrenome;
                TempData["nascimento"] = Convert.ToDateTime(nascimento);
                TempData["usuario"] = usuario;
                TempData["senha"] = senha;
            }
            return View();
        }

        public class Pessoa
        {
            public string nome { get; set; }
            public int idade { get; set; }
            public Pessoa(string nome, int idade){
                this.nome = nome;
                this.idade = idade;
            }

            public string Info(){
                return "Nome: " + this.nome + ". Idade: " + this.idade;
            }
        }
        public IActionResult Exercicio2()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Exercicio2 (string nome1, int idade1, string nome2, int idade2, string nome3, int idade3, string nome4, int idade4, string nome5, int idade5 ){
            if(ModelState.IsValid){
                Pessoa p1 = new Pessoa(nome1, idade1);
                Pessoa p2 = new Pessoa(nome2, idade2);
                Pessoa p3 = new Pessoa(nome3, idade3);
                Pessoa p4 = new Pessoa(nome4, idade4);
                Pessoa p5 = new Pessoa(nome5, idade5);

                List<Pessoa> idades = new List<Pessoa>();
                List<Pessoa> maiores = new List<Pessoa>();
                List<Pessoa> menores = new List<Pessoa>();
                idades.Add(p1);
                idades.Add(p2);
                idades.Add(p3);
                idades.Add(p4);
                idades.Add(p5);

                foreach(Pessoa pessoa in idades){
                    if(pessoa.idade >= 18){
                        maiores.Add(pessoa);
                    } else{
                        menores.Add(pessoa);
                    }
                }

                string maior = "Maiores de Idade:";
                string menor = "Menores de Idade:";

                foreach(Pessoa pessoa in maiores){
                    maior += " | " + pessoa.Info();
                }

                foreach(Pessoa pessoa in menores){
                    menor += " | " + pessoa.Info();
                }

                TempData["maiores"] = maior;
                TempData["menores"] = menor;
            }
            return View();
        }

        public IActionResult Exercicio3()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Exercicio3(string equipe1, string equipe2, string equipe3, string tema1, string tema2, string tema3){
            if(ModelState.IsValid){
                List<string> equipes = new List<string>();
                List<string> temas = new List<string>();

                equipes.Add(equipe1);
                equipes.Add(equipe2);
                equipes.Add(equipe3);

                temas.Add(tema1);
                temas.Add(tema2);
                temas.Add(tema3);

                var quantidade_temas = temas.Count();
                var random = new Random();

                string resultado = "";
                foreach(string equipe in equipes){
                    resultado += " Equipe: " + equipe + " com tema: " + temas[random.Next(0,quantidade_temas -1)] + ". ";
                }

                TempData["sorteio"] = resultado;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

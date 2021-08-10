using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using exportacao.Models;

namespace exportacao.Controllers
{
    public class ExportacaoController : Controller
    {
        //localhost:5001/Exportacao/Cadastro
        public IActionResult Cadastro(){
            return View();
        }

        // Data-annotations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Cadastro(string registro, string volume, string valor, string data) {
            if(ModelState.IsValid)
            {
                DateTime date = Convert.ToDateTime(data);
                float newValue = float.Parse(valor);

                // Verificando se a data registrada está no mês de março, para dar o desconto de 20% sobre o valor
                if(date.Month == 3){
                    newValue = newValue - (newValue*0.2f);
                }

                // Criar o TempData
                TempData["registro"] = registro;
                TempData["data"] = date;
                TempData["volume"] = volume;
                TempData["valor"] = newValue.ToString();

                // Exibindo informações no terminal
                // Console.WriteLine("Número do registro: " + registro);
                // Console.WriteLine("Data: " + Convert.ToDateTime(data));
                // Console.WriteLine("Volume: " + volume);
                // Console.WriteLine("Valor: R$ " + newValue);
            }

            // Redirecionando para outra página dentro do Controller Exportação
            return RedirectToAction(actionName: "Detalhes");
        }

        public IActionResult Detalhes()
            {
                return View();
            }
    }
}
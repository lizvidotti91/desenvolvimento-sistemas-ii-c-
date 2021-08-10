using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moveis_planejados.Models;

namespace moveis_planejados.Controllers
{
    public class VendasController : Controller
    {
        private readonly MoveisPlanejadosContext _context;

        public VendasController(MoveisPlanejadosContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var moveisPlanejadosContext = _context.Vendas.Include(v => v.Funcionario).Include(v => v.Movel);
            return View(await moveisPlanejadosContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Funcionario)
                .Include(v => v.Movel)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewBag.StatusVenda = Services.getStatusVenda().Select( status => new SelectListItem(){
                Text=status.Status, Value=status.StatusValue
            }).ToList();

            List<Funcionario> funcionarios = new List<Funcionario>();
            foreach (var funcionario in _context.Funcionarios)
            {
                if(funcionario.StatusFuncionario == "Disponível"){
                    funcionarios.Add(funcionario);
                }
            }

            if(funcionarios.Count() == 0){
                ViewBag.ListaVazia = "*Não há funcionários disponíveis no momento";
            } else {
                ViewBag.ListaVazia = "";
            }
            ViewData["FuncionarioId"] = new SelectList(funcionarios, "FuncionarioId", "Nome");
            ViewData["MovelId"] = new SelectList(_context.Moveis, "MovelId", "Nome");
            return View();
        }

        /*
        *   Função para mudar o status do funcionário quando é feita uma venda
        *   - Se o status da venda for SOLICITADO ou EM CONSTRUÇÃO, o status do funcionário será INDISPONIVEL
        *   - Se o status da venda for ENTREGUE, o status do funcionário será DISPONIVEL
        */
        public void HandleStatusFuncionario(int FuncionarioId, string StatusVenda){
            if(StatusVenda == "Entregue"){
                    foreach (var funcionario in _context.Funcionarios)
                    {
                        if(funcionario.FuncionarioId == FuncionarioId){
                            funcionario.StatusFuncionario = "Disponível";
                        }
                    }
                } else {
                    foreach (var funcionario in _context.Funcionarios)
                    {
                        if(funcionario.FuncionarioId == FuncionarioId){
                            funcionario.StatusFuncionario = "Indisponível";
                        }
                    }
                }
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaId,Valor,StatusVenda,MovelId,FuncionarioId")] Venda venda, int FuncionarioId, string StatusVenda)
        {
            if (ModelState.IsValid)
            {
                this.HandleStatusFuncionario(FuncionarioId, StatusVenda);
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "FuncionarioId", venda.FuncionarioId);
            ViewData["MovelId"] = new SelectList(_context.Moveis, "MovelId", "MovelId", venda.MovelId);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewBag.StatusVenda = Services.getStatusVenda().Select( status => new SelectListItem(){
                Text=status.Status, Value=status.StatusValue
            }).ToList();

            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "Nome", venda.FuncionarioId);
            ViewData["MovelId"] = new SelectList(_context.Moveis, "MovelId", "Nome", venda.MovelId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaId,Valor,StatusVenda,MovelId,FuncionarioId")] Venda venda, int FuncionarioId, string StatusVenda)
        {
            if (id != venda.VendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.HandleStatusFuncionario(FuncionarioId, StatusVenda);
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "FuncionarioId", venda.FuncionarioId);
            ViewData["MovelId"] = new SelectList(_context.Moveis, "MovelId", "MovelId", venda.MovelId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Funcionario)
                .Include(v => v.Movel)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.VendaId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using loja_chocolates.Models;

namespace loja_chocolates.Controllers
{
    public class ChocolatesController : Controller
    {
        private readonly ChocolateContext _context;

        public ChocolatesController(ChocolateContext context)
        {
            _context = context;
        }

        // GET: Chocolates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chocolates.ToListAsync());
        }

        // GET: Exibir apenas os chocolates com valores maiores que R$ 50,00
        public async Task<IActionResult> Gourmet()
        {
            return View(await _context.Chocolates.Where(chocolate => chocolate.Preco > 50).ToListAsync());
        }

        // GET: Chocolates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chocolate = await _context.Chocolates
                .FirstOrDefaultAsync(m => m.ChocolateId == id);
            if (chocolate == null)
            {
                return NotFound();
            }

            return View(chocolate);
        }

        // GET: Chocolates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chocolates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChocolateId,Marca,PorcentagemCacau,Tipo,DataValidade,Preco")] Chocolate chocolate, float Desconto)
        {
            if (ModelState.IsValid)
            {
                if (chocolate.Preco > Desconto && chocolate.DataValidade > DateTime.Today)
                {
                    chocolate.Preco = chocolate.Preco - Desconto;
                }
                else{
                    return View();
                }
                _context.Add(chocolate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chocolate);
        }

        // GET: Chocolates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chocolate = await _context.Chocolates.FindAsync(id);
            if (chocolate == null)
            {
                return NotFound();
            }
            return View(chocolate);
        }

        // POST: Chocolates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChocolateId,Marca,PorcentagemCacau,Tipo,DataValidade,Preco")] Chocolate chocolate)
        {
            if (id != chocolate.ChocolateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chocolate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChocolateExists(chocolate.ChocolateId))
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
            return View(chocolate);
        }

        // GET: Chocolates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chocolate = await _context.Chocolates
                .FirstOrDefaultAsync(m => m.ChocolateId == id);
            if (chocolate == null)
            {
                return NotFound();
            }

            return View(chocolate);
        }

        // POST: Chocolates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chocolate = await _context.Chocolates.FindAsync(id);
            _context.Chocolates.Remove(chocolate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChocolateExists(int id)
        {
            return _context.Chocolates.Any(e => e.ChocolateId == id);
        }
    }
}

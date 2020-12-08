using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Formula1.Data;
using Formula1.Models;

namespace Formula1.Controllers
{
    public class PosicaoController : Controller
    {
        private readonly Formula1Context _context;
        
        string pontosCorrida;

        public PosicaoController(Formula1Context context)
        {
            _context = context;
        }

        // GET: Posicao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posicao.ToListAsync());
        }

        // GET: Posicao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicao = await _context.Posicao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posicao == null)
            {
                return NotFound();
            }

            return View(posicao);
        }

        // GET: Posicao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posicao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomePiloto,NomeEquipe,PosicaoGrid,PontosCorrida")] Posicao posicao)
        {
            if (ModelState.IsValid)
            {
                SetPonto(posicao.PosicaoGrid);
                posicao.PontosCorrida = pontosCorrida;
                _context.Add(posicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posicao);
        }

        public string SetPonto(string posicaoGrid){


            if (posicaoGrid == "1º Colocado"){
                pontosCorrida = "50 pontos";
            }
            else if (posicaoGrid == "2º Colocado"){
                pontosCorrida = "30 pontos";
            }
            else if (posicaoGrid == "3º Colocado"){
                pontosCorrida = "20 pontos";
            }
            else if (posicaoGrid == "4º Colocado"){
                pontosCorrida = "40 pontos";
            }
            else if (posicaoGrid == "5º Colocado"){
                pontosCorrida = "10 pontos";
            }
            
            return pontosCorrida;
            
        }
        // GET: Posicao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicao = await _context.Posicao.FindAsync(id);
            if (posicao == null)
            {
                return NotFound();
            }
            return View(posicao);
        }

        // POST: Posicao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomePiloto,NomeEquipe,PosicaoGrid,PontosCorrida")] Posicao posicao)
        {
            if (id != posicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosicaoExists(posicao.Id))
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
            return View(posicao);
        }

        // GET: Posicao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicao = await _context.Posicao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posicao == null)
            {
                return NotFound();
            }

            return View(posicao);
        }

        // POST: Posicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posicao = await _context.Posicao.FindAsync(id);
            _context.Posicao.Remove(posicao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosicaoExists(int id)
        {
            return _context.Posicao.Any(e => e.Id == id);
        }
    }
}

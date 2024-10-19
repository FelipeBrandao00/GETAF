using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.ViewModel;

namespace GETAF.Controllers
{
    public class GrupoUsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public GrupoUsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GrupoUsuarios
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.GrupoUsuarios.Include(g => g.Grupo).Include(g => g.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: GrupoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.GrupoUsuarios
                .Include(g => g.Grupo)
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.GrupoId == id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Create
        public IActionResult Create()
        {
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: GrupoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGrupoUsuario([Bind("GrupoId,UsuarioId")] GrupoUsuario grupoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", grupoUsuario.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", grupoUsuario.UsuarioId);
            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.GrupoUsuarios.FindAsync(id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", grupoUsuario.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", grupoUsuario.UsuarioId);
            return View(grupoUsuario);
        }

        // POST: GrupoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrupoId,UsuarioId")] GrupoUsuario grupoUsuario)
        {
            if (id != grupoUsuario.GrupoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoUsuarioExists(grupoUsuario.GrupoId))
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
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", grupoUsuario.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", grupoUsuario.UsuarioId);
            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             
            var grupoUsuario = await _context.GrupoUsuarios
                .Include(g => g.Grupo)
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.GrupoId == id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return View(grupoUsuario);
        }

        // POST: GrupoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoUsuario = await _context.GrupoUsuarios.FindAsync(id);
            if (grupoUsuario != null)
            {
                _context.GrupoUsuarios.Remove(grupoUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoUsuarioExists(int id)
        {
            return _context.GrupoUsuarios.Any(e => e.GrupoId == id);
        }

        public async Task<IActionResult> ReceberCodigo([FromBody] ConvidarParaGrupoModel grupoUsuariosModel)
        {
            var (usuario, resposta) = grupoUsuariosModel.EnviarEmail();

            if (resposta.Sucesso)
            {
                string codigo = (Guid.NewGuid().ToString().Substring(0, 8));
                //colocar validação de gerar o link
                bool emailEnviado = true;
                //bool emailEnviado = await _email.EnviarAsync(usuario.Email, "Código para redefinir senha", $"Seu código para redefinir a senha é: {codigo.ToUpper()}");

                if (emailEnviado)
                {
                    return Json(new { sucesso = resposta.Sucesso && emailEnviado, mensagem = resposta.Mensagem });
                }
            }

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }



        public IActionResult Membros([FromQuery] int grupoId)
        {
            //var grupo = _context.Grupos.Find(grupoId);
            var grupo = _context.GrupoUsuarios.Where(X => X.GrupoId == grupoId).FirstOrDefault(); //ERRO AQUI
            return View(2);
        }
    }
}

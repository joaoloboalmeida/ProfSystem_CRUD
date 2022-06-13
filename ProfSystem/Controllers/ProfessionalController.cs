using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfSystem.Data;
using ProfSystem.Models;

namespace ProfSystem.Controllers
{
    public class ProfessionalController : Controller
    {

        [HttpGet("Professional")]
        public async Task<IActionResult> Index([FromServices] ProfessionalDbContext context)
        {
            try
            {
               return View(await context.Professionals.AsNoTracking().ToListAsync());
            }
            catch
            {
                return StatusCode(500, "01X01 - Falha interna no servidor");
            }
        }

        [HttpGet("Professional/Details/{id:int}")]
        public async Task<IActionResult> Details(int? id,[FromServices] ProfessionalDbContext context)
        {
            var professional = await context.Professionals.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return professional == null ? NotFound("Conteúdo não encontrado") : View(professional);
        }

        public IActionResult Create() => View();

        [HttpPost("Professional/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Rg,Address,Wage")] Professional professional, 
            [FromServices] ProfessionalDbContext context)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await context.Professionals.AddAsync(professional);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(professional);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "01X03 - Falha ao salvar novo registro");
            }
            catch
            {
                return StatusCode(500, "01X04 - Falha interna no servidor");
            }
        }

        public async Task<IActionResult> Edit(int? id, [FromServices] ProfessionalDbContext context)
        {
            if (id == null || context.Professionals == null)
                return NotFound();

            var professional = await context.Professionals.FindAsync(id);
            if (professional == null)
                return NotFound();
            
            return View(professional);
        }

        [HttpPost("Professional/Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Rg,Address,Wage")] Professional professional,
            [FromServices] ProfessionalDbContext context)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = await context.Professionals.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                    if (model == null)
                        return NotFound("Conteúdo não encontrado");

                    model.Name = professional.Name;
                    model.Phone = professional.Phone;
                    model.Rg = professional.Rg;
                    model.Address = professional.Address;
                    model.Wage = professional.Wage;

                    context.Professionals.Update(model);
                    await context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                return View(professional);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "01X02 - Não foi possível atualizar o registro");
            }
            catch
            {
                return StatusCode(500, "01X03 - Falha interna no servidor");
            }

        }

        public async Task<IActionResult> Delete(int? id, [FromServices] ProfessionalDbContext context)
        {
            if (id == null || context.Professionals == null)
                return NotFound();

            var professional = await context.Professionals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
                return NotFound();
            
            return View(professional);
        }

        [HttpPost("Professional/Delete/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, [FromServices] ProfessionalDbContext context)
        {
            var model = await context.Professionals.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
                return NotFound("Conteúdo não encontrado");

            context.Professionals.Remove(model);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfSystem.Data;
using ProfSystem.Models;

namespace ProfSystem.Controllers
{
    public class OvertimeController : Controller
    {

        [HttpGet("Overtime")]
        public async Task<IActionResult> Index([FromServices] ProfessionalDbContext context)
        {
            try
            {
                return View(await context.Professionals.AsNoTracking().ToListAsync());
            }
            catch
            {
                return StatusCode(500, "01X20 - Falha interna no servidor");
            }
        }
        public IActionResult Create() =>View();

        public async Task<IActionResult> Edit(int? id, [FromServices] ProfessionalDbContext context)
        {
            if (id == null || context.Professionals == null)
                return NotFound();

            var professional = await context.Professionals.FindAsync(id);
            if (professional == null)
                return NotFound();

            return View(professional);
        }

        [HttpPost("Overtime/Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id,Hour,Name,Phone,Rg,Address,Wage")] Professional professional,
            [FromServices] ProfessionalDbContext context)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var model = await context.Professionals.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                    if (model == null)
                        return NotFound("Conteúdo não encontrado");


                    model.Hour = professional.Hour;

                    decimal wagePercentage = 0.05m * model.Wage;
                    decimal hourTimesPercentage = model.Hour * wagePercentage;
                    decimal result = model.Wage + hourTimesPercentage;

                    model.WageWithOvertime = result;

                    context.Professionals.Update(model);
                    await context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                return View(professional);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "01X09 - Falha ao verificar as horas extras");
            }
            catch
            {
                return StatusCode(500, "01X10 - Falha interna no servidor");
            }
        }
    }
}
using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agenda.ViewModels;


namespace Agenda.Controllers
{
    [ApiController] //Para dizer que esse controller é para uma pi
    public class ContatoController : ControllerBase
    {
        [HttpGet("/")]//Para dizer que é um GET e já tem a rota ali
        public async Task <IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            return Ok(await context.Contatos.ToListAsync());
        }

        [HttpPost("/")]
        public async Task <IActionResult> PostAsync([FromBody] CreateContatoViewModel model, [FromServices] AppDbContext context)
        {
        
            var contato = new Contato{
                Nome = model.Nome,
                DataNascimento = model.DataNascimento,
                Telefone = model.Telefone
                
            };

            await context.Contatos.AddAsync(contato);
            await context.SaveChangesAsync();

            return Created($"/{contato.Id}", contato);
        }

        [HttpGet("/{id:int}")]
        public async Task <IActionResult> GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var contato =  await context.Contatos.FindAsync(id);

            if(contato is null) return NotFound();

            return Ok(contato);
        }

        [HttpPut("/{id:int}")]
        public async Task <IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] Contato umContato, 
            [FromServices] AppDbContext context)
        {
            var contato = await context.Contatos.FindAsync(id);

            if(contato is null) return NotFound();

            contato.Nome = umContato.Nome;
            contato.Telefone = umContato.Telefone;
            contato.DataNascimento = umContato.DataNascimento;

            context.Contatos.Update(contato);
            await context.SaveChangesAsync();

            return Ok(contato);
        }

        [HttpDelete("/{id:int}")]
        public async Task <IActionResult> DeleteAsync(
            [FromRoute] int id,            
            [FromServices] AppDbContext context)
        {
            var contato = await context.Contatos.FindAsync(id);

            if(contato is null) return NotFound();
            
            context.Contatos.Remove(contato);
            await context.SaveChangesAsync();

            return Ok(contato);
        }
    }    
}
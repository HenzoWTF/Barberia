using Barberia.Data;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;


namespace Barberia.Services;

public class PeladasServices(ApplicationDbContext context)
{
    public async Task<List<Peladas>> GetPeladas()
    {
        return await context.Peladas.ToListAsync();
    }

    public async Task<Peladas?> GetPelada(int id)
    {
        return await context.Peladas.FirstOrDefaultAsync(b => b.peladasId == id);
    }


    public async Task<Peladas> PostPeladas(Peladas Peladas)
    {
        context.Peladas.Add(Peladas);
        await context.SaveChangesAsync();
        return Peladas;

    }
    public async Task<IActionResult> PutPelada(int id, Peladas Peladas)
    {
        if (id != Peladas.peladasId)
        {
            return new BadRequestResult();
        }

        context.Entry(Peladas).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PeladasExists(id))
            {
                return new NotFoundResult();
            }
            else
            {
                throw;
            }
        }

        return new NoContentResult();
    }

    public async Task DeletePeladas(int id)
    {
        var Peladas = await context.Peladas
            .FirstOrDefaultAsync(p => p.peladasId == id);

        if (Peladas != null)
        {
            context.Peladas.Remove(Peladas);
            await context.SaveChangesAsync();
        }
    }
    public bool PeladasExists(int id)
    {
        return context.Peladas.Any(e => e.peladasId == id);
    }
}

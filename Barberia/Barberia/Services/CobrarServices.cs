using Barberia.Data;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Barberia.Services;

public class CobrarServices(ApplicationDbContext context)
{
    public async Task<List<Cobrar>> GetCobra()
    {
        return await context.Cobrar.ToListAsync();
    }

    public async Task<Cobrar?> GetCobrar(int id)
    {
        return await context.Cobrar.FirstOrDefaultAsync(b => b.CobrarId == id);
    }

    public async Task<Cobrar> PostCobrar(Cobrar Cobrar)
    {
        context.Cobrar.Add(Cobrar);
        await context.SaveChangesAsync();
        return Cobrar;

    }
    public async Task<IActionResult> PutPelada(int id, Cobrar Cobrar)
    {
        if (id != Cobrar.CobrarId)
        {
            return new BadRequestResult();
        }

        context.Entry(Cobrar).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CobrarExists(id))
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

    public async Task DeleteCobrar(int id)
    {
        var Cobrar = await context.Cobrar
            .FirstOrDefaultAsync(p => p.CobrarId == id);

        if (Cobrar != null)
        {
            context.Cobrar.Remove(Cobrar);
            await context.SaveChangesAsync();
        }
    }
    public bool CobrarExists(int id)
    {
        return context.Cobrar.Any(e => e.CobrarId == id);
    }
}

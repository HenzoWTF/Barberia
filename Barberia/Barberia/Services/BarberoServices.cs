using Barberia.Data;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Barberia.Services
{
    public class BarberoServices(ApplicationDbContext context)
    {
        public async Task<IEnumerable<Barbero>> GetBarberos()
        {
            return await context.Barbero
            .Select(d => new Barbero()
            {
                BarberoId = d.BarberoId,
                BarberoName = d.BarberoName,
                Celular = d.Celular,
                Direccion = d.Direccion
            }).ToListAsync();
        }
        public async Task<Barbero?> GetBarbero(int id)
        {
            return await context.Barbero.FirstOrDefaultAsync(b => b.BarberoId == id);
        }


        public async Task<Barbero> PostBarberos(Barbero Barbero)
        {
            context.Barbero.Add(Barbero);
            await context.SaveChangesAsync();
            return Barbero;
        }
        public async Task<IActionResult> PutBarbero(int id, Barbero Barbero)
        {
            if (id != Barbero.BarberoId)
            {
                return new BadRequestResult();
            }

            context.Entry(Barbero).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarberosExists(id))
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

        public async Task DeleteBarberos(int id)
        {
            var Barbero = await context.Barbero
                .FirstOrDefaultAsync(p => p.BarberoId == id);

            if (Barbero != null)
            {
                context.Barbero.Remove(Barbero);
                await context.SaveChangesAsync();
            }
        }
        public bool BarberosExists(int id)
        {
            return context.Barbero.Any(e => e.BarberoId == id);
        }
    }
}

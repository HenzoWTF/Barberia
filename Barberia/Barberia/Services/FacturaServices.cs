using Barberia.Data;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;


namespace Barberia.Services;
public class FacturaServices(ApplicationDbContext context)
{
    public async Task<IEnumerable<Factura>> GetFacturas()
    {
        return await context.Facturas
        .Select(d => new Factura()
        {
            FacturaId = d.FacturaId,
            Name = d.Name,
            FormaDePago = d.FormaDePago,
            BarberoName = d.BarberoName,
            Total = d.Total,
            devuelta = d.devuelta,
            Pagado = d.Pagado,
            Fecha = d.Fecha
        }).ToListAsync();
    }
    public async Task<Factura?> GetFactura(int id)
    {
        return await context.Facturas.FirstOrDefaultAsync(b => b.FacturaId == id);
    }


    public async Task<Factura> PostFacturas(Factura Facturas)
    {
        context.Facturas.Add(Facturas);
        await context.SaveChangesAsync();
        return Facturas;

    }
    public async Task<IActionResult> PutFactura(int id, Factura Facturas)
    {
        if (id != Facturas.FacturaId)
        {
            return new BadRequestResult();
        }

        context.Entry(Facturas).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FacturasExists(id))
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

    public async Task DeleteFacturas(int id)
    {
        var Facturas = await context.Facturas
            .FirstOrDefaultAsync(p => p.FacturaId == id);

        if (Facturas != null)
        {
            context.Facturas.Remove(Facturas);
            await context.SaveChangesAsync();
        }
    }
    public bool FacturasExists(int id)
    {
        return context.Facturas.Any(e => e.FacturaId == id);
    }
}

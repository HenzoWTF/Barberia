using Barberia.Data;
using Library;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Services;

public class CuadreServices
{
    private readonly ApplicationDbContext _context;

    public CuadreServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task GuardarCuadreEnBaseDeDatos(DateTime fecha)
    {
        // Calcula el cuadre diario
        var cuadreDiario = await CalcularCuadreDiario(fecha);

        // Guarda el cuadre diario en la base de datos
        _context.Cuadre.Add(cuadreDiario);
        await _context.SaveChangesAsync();
    }

    public async Task<Cuadre> CalcularCuadreDiario(DateTime fecha)
    {
        var cuadre = new Cuadre
        {
            FechaCuadre = fecha.Date
        };

        // Calcular ingresos
        cuadre.Ingresos = await CalcularTotalIngresos(fecha);

        // Calcular gastos
        cuadre.Gastos = await CalcularTotalGastos(fecha);

        // Calcular total
        cuadre.Total = cuadre.Ingresos - cuadre.Gastos;

        return cuadre;
    }

    public async Task<Cuadre> CalcularCuadreSemanal(DateTime fechaInicioSemana)
    {
        var fechaFinSemana = fechaInicioSemana.AddDays(6); // Seis días después de la fecha inicial

        var cuadreSemana = new Cuadre
        {
            FechaCuadre = fechaInicioSemana
        };

        // Calcular ingresos semanales
        cuadreSemana.Ingresos = await CalcularTotalIngresosSemana(fechaInicioSemana, fechaFinSemana);

        // Calcular gastos semanales
        cuadreSemana.Gastos = await CalcularTotalGastosSemana(fechaInicioSemana, fechaFinSemana);

        // Calcular total semanal
        cuadreSemana.Total = cuadreSemana.Ingresos - cuadreSemana.Gastos;

        return cuadreSemana;
    }
    private async Task<float> CalcularTotalIngresos(DateTime fecha)
    {
        var ventas = await _context.Venta
            .Where(v => v.Fecha.Date == fecha.Date)
            .ToListAsync();

        var facturas = await _context.Facturas
            .Where(f => f.Fecha.Date == fecha.Date)
            .ToListAsync();

        float totalVentas = ventas.Sum(v => v.Valor);
        float totalFacturas = facturas.Sum(f => f.Total);

        return totalVentas + totalFacturas;
    }


    private async Task<float> CalcularTotalGastos(DateTime fecha)
    {
        var compras = await _context.Compra
            .Include(c => c.CompraDetalles)
            .Where(c => c.FecheDeCompra.Date == fecha.Date)
            .ToListAsync();

        float totalGastos = 0;

        foreach (var compra in compras)
        {
            totalGastos += compra.CompraDetalles.Sum(cd => cd.PrecioCompra * cd.Cantidad);
        }

        return totalGastos;
    }

    private async Task<float> CalcularTotalIngresosSemana(DateTime fechaInicio, DateTime fechaFin)
    {
        var ventasSemana = await _context.Venta
            .Where(v => v.Fecha.Date >= fechaInicio.Date && v.Fecha.Date <= fechaFin.Date)
            .ToListAsync();

        var facturasSemana = await _context.Facturas
            .Where(v => v.Fecha.Date >= fechaInicio.Date && v.Fecha.Date <= fechaFin.Date)
            .ToListAsync();
        
        float totalVentas = ventasSemana.Sum(v => v.Valor);
        float totalFacturas = facturasSemana.Sum(f => f.Total);

        return totalVentas + totalFacturas;
    }

    private async Task<float> CalcularTotalGastosSemana(DateTime fechaInicio, DateTime fechaFin)
    {
        var comprasSemana = await _context.Compra
            .Include(c => c.CompraDetalles)
            .Where(c => c.FecheDeCompra.Date >= fechaInicio.Date && c.FecheDeCompra.Date <= fechaFin.Date)
            .ToListAsync();

        float totalGastosSemana = 0;

        foreach (var compra in comprasSemana)
        {
            totalGastosSemana += compra.CompraDetalles.Sum(cd => cd.PrecioCompra * cd.Cantidad);
        }

        return totalGastosSemana;
    }
}
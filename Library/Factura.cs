using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;
public class Factura
{
    [Key]
    public int FacturaId { get; set; }
    public string BarberoName { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Name { get; set; }
    public string FormaDePago { get; set; }
    public float Total { get; set; }
    public bool Cobrada { get; set; }
}

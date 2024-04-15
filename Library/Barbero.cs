using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;
public class Barbero
{
    [Key]
    public int BarberoId { get; set; }
    public string BarberoName { get; set; }
    public string Celular { get; set; }
    public string Direccion { get; set; }
    public float Sueldo {  get; set; }
    public float Comision { get; set; }

    [ForeignKey("BarberoId")]
    public List<Factura> Facturas { get; set; } = new List<Factura>();

    [ForeignKey("BarberoId")]
    public List<Cobrar> Cobrar { get; set; } = new List<Cobrar>();
}

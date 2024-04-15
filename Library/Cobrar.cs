using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Cobrar
{
    [Key]
    public int CobrarId { get; set; }
    public string NombreBarbero { get; set; }
    public float Total {  get; set; }
    public float Comision { get; set; }
    public float MontoCobrar { get; set; }
}

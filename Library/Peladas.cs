using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;
public class Peladas
{
    [Key]
    public int peladasId { get; set; }
    public string peladasName { get; set; }
    public float PrecioPelada { get; set; }
}

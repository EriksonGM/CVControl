using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVControl.Data.Entidades
{
    public class EstadoCivil
    {
        [Key]
        public int IdEstadoCivil { get; set; }
        public string Estado { get; set; }
    }
}

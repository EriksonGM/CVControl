using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CVControl.Data.Entidades
{
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }

        public string Nome { get; set; }

        public virtual  ICollection<Municipio> Municipios { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CVControl.Data.Entidades
{
    public class Sintoma
    {
        [Key]
        public int IdSintomas { get; set; }

        public string Nome { get; set; }

        public virtual List<Resultado> Resultados { get; set; }
    }
}
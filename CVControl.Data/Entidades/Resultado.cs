using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVControl.Data.Entidades
{
    public class Resultado
    {
        [Key]
        public Guid IdResultado { get; set; }

        public DateTime DataCriacao { get; set; }

        public string Nome { get; set; }

        public int IdEstadoCivil { get; set; }

        [ForeignKey("IdEstadoCivil")]
        public EstadoCivil EstadoCivil { get; set; }

        public int Filhos { get; set; }

        //public 
    }
}

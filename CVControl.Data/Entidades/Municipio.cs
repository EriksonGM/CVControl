using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVControl.Data.Entidades
{
    public class Municipio
    {
        [Key]
        public int IdMunicipio { get; set; }

        public int IdProvincia { get; set; }

        [ForeignKey("IdProvincia")]
        public Provincia Provincia { get; set; }

        public string Nome { get; set; }
    }
}
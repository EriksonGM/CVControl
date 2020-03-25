using System.ComponentModel.DataAnnotations;

namespace CVControl.Data.Entidades
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }
    }
}
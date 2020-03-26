using System.ComponentModel.DataAnnotations;

namespace CVControl.Data.Entidades
{
    public class IntervaloFilhos
    {
        [Key]
        public int IdIntervaloFilhos { get; set; }

        public string Intervalo { get; set; }
    }
}
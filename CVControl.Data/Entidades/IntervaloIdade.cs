using System.ComponentModel.DataAnnotations;

namespace CVControl.Data.Entidades
{
    public class IntervaloIdade
    {
        [Key]
        public int IdIntervaloIdade { get; set; }
        public string Intervalo { get; set; }
    }
}
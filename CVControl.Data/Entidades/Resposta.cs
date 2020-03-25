using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVControl.Data.Entidades
{
    public class Resposta
    {
        [Key]
        public int IdResposta { get; set; }

        public int IdPergunta { get; set; }

        [ForeignKey("IdPergunta")]
        public Pergunta Pergunta { get; set; }

        [StringLength(500)]
        public string Texto { get; set; }

    }
}
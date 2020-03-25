using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVControl.Data.Entidades
{
    public class Pergunta
    {
        [Key]
        public int IdPergunta { get; set; }

        [StringLength(500)]
        public string Texto { get; set; }

        public virtual ICollection<Resposta> Respostas { get; set; }
    }
}

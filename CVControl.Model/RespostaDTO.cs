using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVControl.Model
{
    public class RespostaDTO
    {
        public int IdResposta { get; set; }

        public int IdPergunta { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "{0} tem um limite de {1} caracteres.")]
        public string Texto { get; set; }

    }
}

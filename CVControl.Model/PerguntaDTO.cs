using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CVControl.Model
{
    public class PerguntaDTO
    {
        public int IdPergunta { get; set; }

        [Required]
        [StringLength(500,ErrorMessage = "{0} tem um limite de {1} caracteres.")]
        public string Texto { get; set; }

        public List<RespostaDTO> Respostas { get; set; }
    }
}

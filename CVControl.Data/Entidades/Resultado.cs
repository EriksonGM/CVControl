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
        public int IdMunicipio { get; set; }
        [ForeignKey("IdMunicipio")]
        public Municipio Municipio { get; set; }
        public int IdEstadoCivil { get; set; }
        [ForeignKey("IdEstadoCivil")]
        public EstadoCivil EstadoCivil { get; set; }
        public int IdGenero { get; set; }
        [ForeignKey("IdGenero")]
        public Genero Genero { get; set; }
        public int IdIntervaloIdade { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int Filhos { get; set; }
        public bool Febre { get; set; } 
        public bool Medicacao { get; set; } 
        public bool Contacto { get; set; } 
        public bool Viagem { get; set; } 
        public bool Sintomas { get; set; } 
        public bool Gravida { get; set; } 
    }
}

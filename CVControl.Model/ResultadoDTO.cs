using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CVControl.Model
{
    public class ResultadoDTO
    {
        public Guid IdResultado { get; set; }
        public DateTime DataCriacao { get; set; }

        [Required]
        public string Nome { get; set; }
        public int IdMunicipio { get; set; }
        public MunicipioDTO Municipio { get; set; }
        public int IdEstadoCivil { get; set; }
        public EstadoCivilDTO EstadoCivil { get; set; }
        public int IdGenero { get; set; }
        public GeneroDTO Genero { get; set; }
        public int IdIntervaloIdade { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Telefone { get; set; }
        public int IdIntervaloFilhos { get; set; }
        public IntervaloFilhosDTO IntervaloFilhos { get; set; }
        public bool Febre { get; set; }
        public bool Medicacao { get; set; }
        public bool Contacto { get; set; }
        public bool Viagem { get; set; }
        public bool Gravida { get; set; }
        public virtual List<SintomaDTO> Sintomas { get; set; }
    }
}
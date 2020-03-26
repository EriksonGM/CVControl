using System.Collections.Generic;

namespace CVControl.Model
{
    public class ProvinciaDTO
    {
        public int IdProvincia { get; set; }

        public string Nome { get; set; }

        public List<MunicipioDTO> Municipios { get; set; } 
    }
}
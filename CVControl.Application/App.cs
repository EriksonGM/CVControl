using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CVControl.Application.Mappers;
using CVControl.Data;

namespace CVControl.Application
{
    public abstract class App 
    {
        public DataContext db = new DataContext();

        public IMapper mapper;

        protected App()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EstadoCivilProfile>();
                cfg.AddProfile<MunicipioProfile>();
                cfg.AddProfile<ProvinciaProfile>();
                cfg.AddProfile<IntervaloIdadeProfile>();
                cfg.AddProfile<GeneroProfile>();
                cfg.AddProfile<SintomaProfile>();
            });

            mapper = config.CreateMapper();
        }

        public class AppResultado
        {
            public bool Exito { get; set; }

            public string Mensagem { get; set; }

            public object Objeto { get; set; }

            public AppResultado Good(string msg, object obj = null)
            {
                Exito = true;
                Mensagem = msg;
                if (obj != null)
                {
                    Objeto = obj;
                }
                return this;
            }

            public AppResultado Bad(string msg, object obj = null)
            {
                Exito = false;
                Mensagem = msg;
                if (obj != null)
                {
                    Objeto = obj;
                }
                return this;
            }

            public AppResultado Good(object obj)
            {
                Exito = true;
                if (obj != null)
                {
                    Objeto = obj;
                }
                return this;
            }

            public AppResultado Bad(object obj)
            {
                Exito = false;
                if (obj != null)
                {
                    Objeto = obj;
                }
                return this;
            }

        }
    }
}

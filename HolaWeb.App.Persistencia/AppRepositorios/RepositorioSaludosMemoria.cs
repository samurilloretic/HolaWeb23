using System.Collections.Generic;
using HolaWeb.App.Dominio;
using System;
using System.Linq;

namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public class RepositorioSaludosMemoria : IRepositorioSaludos
    {
        List<Saludo> saludos;

        public RepositorioSaludosMemoria()
        {
            saludos= new List<Saludo>()
            {
                new Saludo{Id=1,EnEspañol="Buenos Dias",EnIngles="Good Morning",EnItaliano="Bungiorno"},
                new Saludo{Id=2,EnEspañol="Buenas Tardes",EnIngles="Good Afternoon",EnItaliano="Buon pomeriggio"},
                new Saludo{Id=3,EnEspañol="Buenas Noches",EnIngles="Good Evening",EnItaliano="Buona notte"}
            };
        }
        public IEnumerable<Saludo> GetAll()
        {
            return saludos;
        }

        public IEnumerable<Saludo> GetSaludosPorFiltro (string filtro=null)
        {
            var saludos = GetAll();
            if (saludos!=null)
            {
                if(!String.IsNullOrEmpty(filtro))
                {
                    saludos = saludos.Where(s=>s.EnEspañol.Contains(filtro));                    
                }
            }
            return saludos;
        }
    }
}
using System.Collections.Generic;
using HolaWeb.App.Dominio;
using System;
using System.Linq;

namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public class RepositorioSaludosMemoria : IRepositorioSaludos
    {
        List<Saludo> saludos;
        Saludo saludo;
        public RepositorioSaludosMemoria()
        {
            saludos= new List<Saludo>()
            {
                new Saludo{Id=1,EnEspañol="Buenos Dias",EnIngles="Good Morning",EnItaliano="Bungiorno"},
                new Saludo{Id=2,EnEspañol="Buenas Tardes",EnIngles="Good Afternoon",EnItaliano="Buon pomeriggio"},
                new Saludo{Id=3,EnEspañol="Buenas Noches",EnIngles="Good Evening",EnItaliano="Buona notte"},
                new Saludo{Id=4,EnEspañol="Hora inválida",EnIngles="invalid hour",EnItaliano="Tempo no valido"}
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


        public Saludo GetSaludoPorId(int Id){
            return saludos.SingleOrDefault(s=>s.Id==Id);
        }


        public Saludo GetSaludoPorHora(int filtro)
        {
            if (filtro<12)
            {
                saludo = GetSaludoPorId(1);
            }else if(filtro <18)
            {
                saludo = GetSaludoPorId(2);
            }else if(filtro < 24)
            {
                saludo = GetSaludoPorId(3);
            }else if (filtro>=24 | filtro<0)
            {
                saludo = GetSaludoPorId(4);
            }
            return saludo;
        }

        public Saludo GetSaludoPorHora(DateTime filtro)
        {
            if (filtro<Convert.ToDateTime("12:00:00"))
            {
                saludo = GetSaludoPorId(1);
            }else if(filtro <Convert.ToDateTime("18:00:00"))
            {
                saludo = GetSaludoPorId(2);
            }else if(filtro < Convert.ToDateTime("23:59:00"))
            {
                saludo = GetSaludoPorId(3);
            }else if (filtro>=Convert.ToDateTime("23:59:00") | filtro<Convert.ToDateTime("00:00:00"))
            {
                saludo = GetSaludoPorId(4);
            }
            return saludo;
        }

        public Saludo Update(Saludo saludoActualizado)
        {
            var saludo = saludos.SingleOrDefault(r=>r.Id==saludoActualizado.Id);
            if (saludo!=null)
            {
                saludo.EnEspañol = saludoActualizado.EnEspañol;
                saludo.EnIngles = saludoActualizado.EnIngles;
                saludo.EnItaliano = saludoActualizado.EnItaliano;
            }
            return saludo;
        }

        public Saludo Add(Saludo nuevoSaludo)
        {
            //Console.WriteLine(saludos.Count);
            if (saludos.Count==0)
            {
                nuevoSaludo.Id = 1;
            }else{
                nuevoSaludo.Id = saludos.Max(r => r.Id) + 1;
            }
            saludos.Add(nuevoSaludo);
            return nuevoSaludo;
        }

        public Saludo Delete(Saludo eliminarSaludo)
        {
            var idSaludoEliminar = saludos.Single(r=>r.Id==eliminarSaludo.Id);
            saludos.Remove(idSaludoEliminar);
            return eliminarSaludo;
        }
    }
}
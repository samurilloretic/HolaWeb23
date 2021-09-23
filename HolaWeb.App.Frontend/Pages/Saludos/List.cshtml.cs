using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolaWeb.App.Dominio;
using HolaWeb.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace HolaWeb.App.Frontend.Pages
{
    public class ListModel : PageModel
    {
       //private string[] saludos = { "Buenos dias", "Buenas tardes", "Buenas noches", "Hasta mañana" ,"Hola Mundo"};
       //public List<string> ListaSaludos { get; set; }
        private readonly IRepositorioSaludos repositorioSaludos;
        public IEnumerable<Saludo> Saludos {get;set;}
        public string FiltroBusqueda{get;set;}
        //public int FiltroHora{get;set;}
        public DateTime FiltroHora{get;set;}
        public Saludo Saludo;
        public ListModel(IRepositorioSaludos repositorioSaludos)
        {
                this.repositorioSaludos=repositorioSaludos;
        }
       
        /*public void OnGet(string filtroBusqueda)
        {
            //ListaSaludos = new List<string>();
            //ListaSaludos.AddRange(saludos);
            //Saludos=repositorioSaludos.GetAll();
            FiltroBusqueda=filtroBusqueda;
            Saludos=repositorioSaludos.GetSaludosPorFiltro(FiltroBusqueda);
        }*/

        /*public void OnGet(int filtroHora)
        {
            FiltroHora=filtroHora;
            Saludo=repositorioSaludos.GetSaludoPorHora(FiltroHora);
        }*/


        public void OnGet(DateTime filtroHora)
        {
            FiltroHora=filtroHora;
            Saludo=repositorioSaludos.GetSaludoPorHora(FiltroHora);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HolaWeb.App.Persistencia.AppRepositorios;
using HolaWeb.App.Dominio;

namespace HolaWeb.App.Frontend.Pages
{
    public class editModel : PageModel
    {
        private readonly IRepositorioSaludos repositorioSaludos;
        [BindProperty]
        public Saludo Saludo{get;set;}

        public editModel(IRepositorioSaludos repositorioSaludos)
        {
            this.repositorioSaludos=repositorioSaludos;
        }

        public IActionResult OnGet(int saludoId)
        {
            Saludo = repositorioSaludos.GetSaludoPorId(saludoId);
            if(Saludo==null)
            {
                return RedirectToPage("./List");                
            }
            else 
            return Page();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("Id Saludo");
            Console.WriteLine(Saludo.Id);
            Saludo = repositorioSaludos.Update(Saludo);
            return Page();
        }
    }
}

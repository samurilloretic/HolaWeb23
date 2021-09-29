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
    public class DeleteModel : PageModel
    {
        
        private readonly IRepositorioSaludos repositorioSaludos;
        [BindProperty]
        public Saludo Saludo{get;set;}

        public DeleteModel(IRepositorioSaludos repositorioSaludos)
        {
            this.repositorioSaludos=repositorioSaludos;
        }

        public IActionResult OnGet(int saludoId)
        {
            Saludo = repositorioSaludos.GetSaludoPorId(saludoId);
            return Page();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine(Saludo.EnItaliano);
            repositorioSaludos.Delete(Saludo);
            return RedirectToPage("./List");
        }
    }

    
}

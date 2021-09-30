using System;
using System.ComponentModel.DataAnnotations;

namespace HolaWeb.App.Dominio
{
    public class Saludo
    {
        public int Id {get;set;}
        [Required(ErrorMessage="El saludo en español es obligatorio"),StringLength(50)]
        public string EnEspañol {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio"),StringLength(50)]
        public string EnIngles {get;set;}
        [Url]
        public string EnItaliano {get;set;}
    }
}

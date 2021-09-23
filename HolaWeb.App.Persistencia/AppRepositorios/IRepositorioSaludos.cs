using System.Collections.Generic;
using HolaWeb.App.Dominio;

namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public interface IRepositorioSaludos
    {
        IEnumerable<Saludo> GetAll();

        IEnumerable<Saludo> GetSaludosPorFiltro(string filtro);
         
        Saludo GetSaludoPorHora(int filtro); 

        Saludo GetSaludoPorId(int id);
    }
}
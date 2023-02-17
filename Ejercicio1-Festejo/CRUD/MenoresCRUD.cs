using Ejercicio1_Festejo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_Festejo.CRUD
{
    public class MenoresCRUD
    {

        FestejoContext contenedor = new();



        public IEnumerable<Menor> ObtenerMenores()
        {
            return contenedor.Menor.OrderBy(x => x.Nombre);
        }
        public IEnumerable<Vwcumplenhoy> CumplenHoy()
        {
            return contenedor.Vwcumplenhoy.OrderBy(x => x.Nombre);
        }
        public IEnumerable<Vwcumplenmes> CumplenMes()
        {
            return contenedor.Vwcumplenmes.OrderBy(x => x.Nombre);
        }
        public IEnumerable<Vwmenoresdoce> MenoresDoce()
        {
            return contenedor.Vwmenoresdoce.OrderBy(x => x.Nombre);
        }

        public IEnumerable<DatosMenoresCumplenHoy> GetMenoresCumplenHoy()
        {
            return contenedor.Menor.Where(x => x.FechaNacimiento.Month.Equals(DateTime.Now.Month) && x.FechaNacimiento.Day.Equals(DateTime.Now.Day)).OrderBy(x => x.Nombre).Select(x => new DatosMenoresCumplenHoy
            {
                Nombre = x.Nombre,
                Domicilio = x.Domicilio
            });
        }

        public IEnumerable<DatosMenoresPorAño> ObtenerMenoresPorAño()
        {
            return contenedor.Menor
                .GroupBy(x => x.FechaNacimiento.Year)
                .Select(x => new DatosMenoresPorAño
                {
                    Año = x.Key,
                    Cantidad = x.Count()
                });
        }

        public IEnumerable<DatosMenoresDiciembre> ObtenerMenoresDiciembre()
        {
            return contenedor.Menor
                .Where(x => x.FechaNacimiento.Month.Equals(12))
                .OrderBy(x => x.Nombre)
                .Select(x => new DatosMenoresDiciembre
                {
                    Nombre = x.Nombre,
                    Domicilio = x.Domicilio
                });
        }

    }

}

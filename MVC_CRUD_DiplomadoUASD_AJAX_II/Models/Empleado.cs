using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_AJAX_II.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public String Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Estado_Civil { get; set; }
        public string Pais { get; set; }
    }
}
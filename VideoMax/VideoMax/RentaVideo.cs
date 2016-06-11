using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoMax
{
    class RentaVideo
    {
        public int Id_Socio { get; set; }
        public int Id_Pelicula { get; set; }
        public int Id_Ejemplar { get; set; }
        public String Fecha_Incio { get; set; }
        public String Fecha_Fin { get; set; }
        public RentaVideo() { }
        public RentaVideo(int Id_Socio, int Id_Pelicula, int Id_Ejemplr, String Fecha_Inicio, String Fecha_Fin)
        {
            this.Id_Socio = Id_Socio;
            this.Id_Pelicula = Id_Pelicula;
            this.Id_Ejemplar=Id_Ejemplar;
            this.Fecha_Incio = Fecha_Incio;
            this.Fecha_Fin = Fecha_Fin;
        }

    }
}

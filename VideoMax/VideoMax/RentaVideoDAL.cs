using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace VideoMax
{
    class RentaVideoDAL
    {
        
        public static void AgregarRentaVideo(RentaVideo pRentaVideo)
        {
            BD_Comun conex = new BD_Comun();
            DataSet DS = conex.ExecuteDataSet("Insert into SOCIO_EJEMPLAR values("+ pRentaVideo.Id_Socio + "," + pRentaVideo.Id_Pelicula + "," + pRentaVideo.Id_Ejemplar + ",'" + Convert.ToDateTime(pRentaVideo.Fecha_Incio)+"','"+
                Convert.ToDateTime(pRentaVideo.Fecha_Fin)+"')");
            
        }


        public static DataTable ConsultarEjemplar(String Pelicula)
        {
            BD_Comun conex = new BD_Comun();
            DataSet DS = conex.ExecuteDataSet("exec disponibilidad_Ejemplar @TituloPelicula='" + Pelicula + "'");
            DataTable DT = DS.Tables[0];
            return DT;

        }
        public static int consultar_id_DNI(String Cedula)
        {
            DataTable DT;
            BD_Comun conex = new BD_Comun();
            try
            {

                DataSet DS = conex.ExecuteDataSet("exec recuperar_id_socio @DNI_socio='" + Cedula + "'");
                DT = DS.Tables[0];
                return int.Parse(DT.Rows[0][0].ToString());

            }
            catch {
                return 1;
            }
        }


        //exec recuperar_id_socio @DNI_socio='1789384958'


        public static String ConsultarDisponibilidadEjemplar(int idEjemplar, int idPelicula)
        {
             DataTable DT;
            BD_Comun conex = new BD_Comun();
            try
            {
                DataSet DS = conex.ExecuteDataSet("exec disponibilidad @id_ejemplar=" + idEjemplar + ", @id_pelicula=" + idPelicula);
                DT= DS.Tables[0];
                return DT.Rows[0][0].ToString();
            }
            catch {
                return "false";
            }

        }





    }
}

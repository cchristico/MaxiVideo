using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoMax
{
    public partial class Form1 : Form
    {
        private Boolean ingresoIdentificado = false;
        int[] id_pel_ej = new int[2];
        
        public Form1()
        {
            
            InitializeComponent();
            
            
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();

            us.Show();
        }
        private void listarHistorial() {
            
            DataTable DT = RentaVideoDAL.ConsultarEjemplar(txtNombrePelicula.Text);
            dataGridView1.DataSource = DT;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //ocultar las columnas de id
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (consultarIdUser())
            {
                // if (!ingresoIdentificado)
                // {
                RentaVideo rVideo = new RentaVideo();
                rVideo.Id_Pelicula = id_pel_ej[0];
                rVideo.Id_Ejemplar = id_pel_ej[1];
                MessageBox.Show(id_pel_ej[0].ToString() + "-...-" + id_pel_ej[1]);


                rVideo.Id_Socio = 3;//int.Parse(txtIdUsuario.Text);
                rVideo.Fecha_Incio = fechaUsr.Value.Date.ToString("yyyy-MM-dd HH:mm:s");
                rVideo.Fecha_Fin = dateDev.Value.Date.Date.ToString("yyyy-MM-dd HH:mm:s");

                RentaVideoDAL.AgregarRentaVideo(rVideo);

            }
          //  }
          //  else {
          //      MessageBox.Show("El ejemplar no se encuntra disponible");
          //  }
 

        }
        /*
         * Listar la disponibilidad de las peliculas(ejemplares y su historial)
         */
        private void txtNombrePelicula_TextChanged_1(object sender, EventArgs e)
        {
            listarHistorial();
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Captura de los id pra el insert
             * id_pel_ej
             * id_pelicula, id_ejemplar para verificar la siponibilidad, si hay disponibilidad cargar datos para alquiler de pelicula
             */
            id_pel_ej[0] = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
            id_pel_ej[1] = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim());
            String dispo = RentaVideoDAL.ConsultarDisponibilidadEjemplar(id_pel_ej[0], id_pel_ej[1]);
            if (dispo.Equals("True"))
            {
                lblDisponibilidad.Text="Disponible";
                ingresoIdentificado = true;
                MessageBox.Show(id_pel_ej[0] + "--" + id_pel_ej[1]);
            }
            else {
                lblDisponibilidad.Text="Rentada";
            }
        }

        private bool consultarIdUser()
        {
            if (RentaVideoDAL.consultar_id_DNI(txtIdUsuario.Text)==1)
            {
                MessageBox.Show("El usuario no existe");
                return false;

            }
            else {

                return true;
            }
                    
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using VideoMax.Properties;
using System.Configuration;

namespace VideoMax
{
    class BD_Comun
    {
        public void ExecuteNonQuery(string strSQL)
        {
            SqlConnection cnn = null;
            //SqlTransaction trans = cnn.BeginTransaction();
            try
            {
                cnn = new SqlConnection(ObtenerConexion());
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                //cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //trans.Rollback();   
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        

        
        public DataSet ExecuteDataSet(string strSQL)
        {
            DataSet ds = new DataSet();
            SqlConnection cnn = null;
            //SqlTransaction trans = cnn.BeginTransaction();

            try
            {
                cnn = new SqlConnection(ObtenerConexion());

                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                //cmd.Transaction = trans;
                cmd.CommandTimeout = 0; // infinito

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds, "tabla1");
                return ds;
            }

            catch (Exception)
            {
                //trans.Rollback();
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }


        }


        public string ObtenerConexion()
        {       
            try
            {
                return Settings.Default.escenario_peliculasConnectionString;// @"Data Source=(local);Initial Catalog=escenario_peliculas;Integrated Security=True";
            }
            catch{
                throw;
            }

        }
    }
}

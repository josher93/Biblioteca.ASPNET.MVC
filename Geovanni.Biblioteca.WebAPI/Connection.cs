using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.WebAPI
{
    public class Connection
    {

        private SqlConnection cnn;
        private SqlCommand com;
        private SqlTransaction tra;

        public SqlConnection Cnn
        {
            get
            {
                return cnn;
            }
            set
            {
                cnn = value;
            }
        }


        public SqlCommand Com
        {
            get
            {
                return com;
            }
            set
            {
                com = value;
            }
        }


        public SqlTransaction Tra
        {
            get
            {
                return tra;
            }
            set
            {
                tra = value;
            }
        }


        public Connection()
        {
            initialize();
        }

        private void initialize()
        {
            string connectcion = ConfigurationManager.AppSettings["BibliotecaDB"].ToString();

            cnn = new SqlConnection(connectcion);
            com = new SqlCommand();
            com.Connection = cnn;
            com.CommandType = CommandType.StoredProcedure;
        }

     


        public static IEnumerable<T> Query<T>(string sql, object param = null)
        {

            string connectcion = ConfigurationManager.AppSettings["BibliotecaDB"].ToString();

            using (SqlConnection sconn = new SqlConnection(connectcion))
            {
                SqlTransaction transaction;

                sconn.Open();

                transaction = sconn.BeginTransaction("RGTransaction");

                try
                {

                    var query = sconn.Query<T>(sql, param, transaction);

                    transaction.Commit();

                    sconn.Close();
                    return query;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error Connection: " + ex.Message);
                    return null;
                }
            }
        }
    }
}

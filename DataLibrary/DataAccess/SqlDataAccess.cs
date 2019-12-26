using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "CarRepairDB") {
            //return System.Configuration.ConfigurationManager.ConnectionString[connectionName].ConnectionString;

            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static List<T> LoadData<T>(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, new { id }).ToList(); // the id is added as such new { id }
            }
        }


        public static T LoadOne<T>(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, new { id }).FirstOrDefault();//Returning one individual item
            }
        }


        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        //Delete data
        public static void DeleteData(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(sql, new { id });//modify to allow the Id parameter to be used by //new {id}
            }
        }

        //Update data
        public static void UpdateData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(sql, new { data });
            }
        }


    }
}

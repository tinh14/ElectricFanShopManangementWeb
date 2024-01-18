using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using QuanLyShopBanQuatDien.Mappers;
using QuanLyShopBanQuatDien.Database;

namespace QuanLyShopBanQuatDien.DAO
{
    public class DatabaseQueryExecutor
    {

        public static bool executeUpdate(string sql, SqlParameter[] parameters)
        {
            SqlConnection con = DatabaseConnectionProvider.openConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            bool result = cmd.ExecuteNonQuery() > 0;

            DatabaseConnectionProvider.closeConnection(con);

            return result;
        }

        public static List<T> executeQuery<T>(string sql, RowMapper<T> mapper, SqlParameter[] parameters = null)
        {
            SqlConnection con = DatabaseConnectionProvider.openConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            SqlDataReader reader = cmd.ExecuteReader();

            List<T> objs = new List<T>();

            while (reader.Read())
            {
                objs.Add(mapper.map(reader));
            }

            DatabaseConnectionProvider.closeConnection(con);

            return objs;
        }

        public static bool executeExist(string sql, SqlParameter[] parameters)
        {
            SqlConnection con = DatabaseConnectionProvider.openConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            SqlDataReader reader = cmd.ExecuteReader();

            bool result = reader.Read();

            DatabaseConnectionProvider.closeConnection(con);

            return result;
        }

        public static Int64 executeScalar(string sql, SqlParameter[] parameters)
        {
            sql += "; SELECT SCOPE_IDENTITY();";

            SqlConnection con = DatabaseConnectionProvider.openConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            Int64 id = Convert.ToInt32(cmd.ExecuteScalar());

            DatabaseConnectionProvider.closeConnection(con);

            return id;
        }

    }
}
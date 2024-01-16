using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Mappers;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.DAO
{
    public class CustomerDAO
    {

        public static List<CustomerEntity> findAll()
        {
            string sql = "select * from customer ";
            return DatabaseQueryExecutor.executeQuery(sql, new CustomerMapper());
        }

        public static List<CustomerEntity> findByName(string name)
        {
            string sql = "select * from customer where customerName like @name";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@name", "%"+name+"%")
            };
            return DatabaseQueryExecutor.executeQuery(sql, new CustomerMapper(), parameters);
        }

        public static List<CustomerEntity> findByCode(string code)
        {
            string sql = "select * from customer where customerCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new CustomerMapper(), parameters);
        }

        public static bool checkExist(string code)
        {
            string sql = "select * from customer "
                       + "where customerCode = @code";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeExist(sql, parameters);
        }

        public static bool create(CustomerEntity customer)
        {
            string sql = "insert into customer values (@code, @name, @phoneNumber)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", customer.code),
                new SqlParameter("@name", customer.name),
                new SqlParameter("@phoneNumber", customer.phoneNumber)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool update(CustomerEntity customer)
        {
            string sql = "update customer set customerName = @name, phoneNumber = @phoneNumber "
                        +"where customerCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@name", customer.name),
                new SqlParameter("@phoneNumber", customer.phoneNumber),
                new SqlParameter("@code", customer.code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool delete(string code)
        {
            string sql = "delete from customer where customerCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}
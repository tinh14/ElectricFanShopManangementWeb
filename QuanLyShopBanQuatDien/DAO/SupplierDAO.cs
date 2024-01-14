using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using System.Data.SqlClient;
using QuanLyShopBanQuatDien.Mappers;

namespace QuanLyShopBanQuatDien.DAO
{
    public class SupplierDAO
    {
        public static List<SupplierEntity> findAll()
        {
            string sql = "select * from supplier ";
            return DatabaseQueryExecutor.executeQuery(sql, new SupplierMapper());
        }

        public static List<SupplierEntity> findByName(string name)
        {
            string sql = "select * from supplier where supplierName like @name";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@name", "%"+name+"%")
            };
            return DatabaseQueryExecutor.executeQuery(sql, new SupplierMapper(), parameters);
        }

        public static List<SupplierEntity> findByCode(string code)
        {
            string sql = "select * from supplier where supplierCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeQuery(sql, new SupplierMapper(), parameters);
        }

        public static bool checkExist(string code)
        {
            string sql = "select * from supplier "
                       + "where supplierCode = @code";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@code", code)
            };

            return DatabaseQueryExecutor.executeExist(sql, parameters);
        }

        public static bool create(SupplierEntity supplier)
        {
            string sql = "insert into supplier values (@code, @name, @contactPerson, "
                        +"@phoneNumber, @address)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", supplier.code),
                new SqlParameter("@name", supplier.name),
                new SqlParameter("@contactPerson", supplier.contactPerson),
                new SqlParameter("@phoneNumber", supplier.phoneNumber),
                new SqlParameter("@address", supplier.address)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool update(SupplierEntity supplier)
        {
            string sql = "update supplier set supplierName = @name, contactPerson = @contactPerson, "
                        +"phoneNumber = @phoneNumber, address = @address "
                        + "where supplierCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@name", supplier.name),
                new SqlParameter("@contactPerson", supplier.contactPerson),
                new SqlParameter("@phoneNumber", supplier.phoneNumber),
                new SqlParameter("@address", supplier.address),
                new SqlParameter("@code", supplier.code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool delete(string code)
        {
            string sql = "delete from supplier where supplierCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}
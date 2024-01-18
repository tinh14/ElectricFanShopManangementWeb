using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Mappers;
using System.Data.SqlClient;

namespace QuanLyShopBanQuatDien.DAO
{
    public class GRNDAO
    {
        public static List<GRNEntity> findAll()
        {
            string sql = "select * from [grn]";
            return DatabaseQueryExecutor.executeQuery(sql, new GRNMapper());
        }

        public static List<GRNEntity> findByCode(string code)
        {
            string sql = "select * from [grn] where grnCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeQuery(sql, new GRNMapper(), parameters);
        }

        public static List<GRNEntity> findByCodeWithWildCard(string code)
        {
            string sql = "select * from [grn] where grnCode like @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", "%"+code+"%")
            };
            return DatabaseQueryExecutor.executeQuery(sql, new GRNMapper(), parameters);
        }

        public static bool checkExist(string code)
        {
            string sql = "select * from [grn] where grnCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeExist(sql, parameters);
        }

        public static bool create(GRNEntity grn)
        {
            string sql = "insert into [grn] values (@code, @grnDate, @totalAmount, @supplierCode, @username)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", grn.code),
                new SqlParameter("@grnDate", grn.grnDate),
                new SqlParameter("@totalAmount", grn.totalAmount),
                new SqlParameter("@supplierCode", grn.supplier.code),
                new SqlParameter("@username", grn.user.username)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool update(GRNEntity grn)
        {
            string sql = "update [grn] set grnDate = @grnDate, "
                + "totalAmount = @totalAmount, supplierCode = @supplierCode, username = @username "
                + "where grnCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@grnDate", grn.grnDate),
                new SqlParameter("@totalAmount", grn.totalAmount),
                new SqlParameter("@supplierCode", grn.supplier.code),
                new SqlParameter("@username", grn.user.username),
                new SqlParameter("@code", grn.code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }

        public static bool delete(string code)
        {
            string sql = "delete from [grn] where grnCode = @code";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@code", code)
            };
            return DatabaseQueryExecutor.executeUpdate(sql, parameters);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Service
{
    public class SupplierService
    {
        public static List<SupplierEntity> findAll()
        {
            return SupplierDAO.findAll();
        }

        public static List<SupplierEntity> findByName(string name)
        {
            return SupplierDAO.findByName(name);
        }

        public static SupplierEntity findByCode(string code)
        {
            List<SupplierEntity> suppliers = SupplierDAO.findByCode(code);

            return DataUtils.isEmpty(suppliers) ? null : suppliers[0];
        }

        public static bool create(SupplierEntity Supplier)
        {
            if (SupplierDAO.checkExist(Supplier.code))
            {
                return false;
            }

            return SupplierDAO.create(Supplier);
        }

        public static bool update(SupplierEntity Supplier)
        {
            if (!SupplierDAO.checkExist(Supplier.code))
            {
                return false;
            }

            return SupplierDAO.update(Supplier);
        }

        public static bool delete(string code)
        {
            if (!SupplierDAO.checkExist(code))
            {
                return false;
            }
            return SupplierDAO.delete(code);
        }
    }
}
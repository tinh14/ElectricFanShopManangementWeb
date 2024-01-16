using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Pages.Utils;

namespace QuanLyShopBanQuatDien.Service
{
    public class CustomerService
    {

        public static List<CustomerEntity> findAll()
        {
            return CustomerDAO.findAll();
        }

        public static List<CustomerEntity> findByName(string name)
        {
            return CustomerDAO.findByName(name);
        }

        public static CustomerEntity findByCode(string code)
        {
            List<CustomerEntity> customers = CustomerDAO.findByCode(code);

            return DataUtils.isEmpty(customers) ? null : customers[0];
        }

        public static bool create(CustomerEntity customer)
        {
            if (CustomerDAO.checkExist(customer.code))
            {
                return false;
            }

            return CustomerDAO.create(customer);
        }

        public static bool update(CustomerEntity customer)
        {
            if (!CustomerDAO.checkExist(customer.code))
            {
                return false;
            }

            return CustomerDAO.update(customer);
        }

        public static bool delete(string code) {
            if (!CustomerDAO.checkExist(code))
            {
                return false;
            }
            return CustomerDAO.delete(code);
        }

    }
}
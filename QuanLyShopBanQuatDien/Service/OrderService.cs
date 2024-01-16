using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Entities;

namespace QuanLyShopBanQuatDien.Service
{
    public class OrderService
    {

        public static List<OrderEntity> findAll()
        {
            return OrderDAO.findAll();
        }

        public static List<OrderEntity> findByCodeWithWildCard(string code)
        {
            return OrderDAO.findByCodeWithWildCard(code);
        }


        public static OrderEntity findByCode(string code)
        {
            List<OrderEntity> orders = OrderDAO.findByCode(code);
            if (DataUtils.isEmpty(orders))
            {
                return null;
            }

            OrderEntity order = orders[0];

            List<OrderDetailEntity> orderDetails = OrderDetailDAO.findByOrderCode(code);
            order.orderDetails = orderDetails;

            return order;
        }

        internal static bool delete(string code)
        {
            throw new NotImplementedException();
        }

        internal static bool create(OrderEntity order)
        {
            throw new NotImplementedException();
        }

        internal static bool update(OrderEntity order)
        {
            throw new NotImplementedException();
        }
    }
}
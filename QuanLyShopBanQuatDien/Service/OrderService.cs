using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Pages;
using QuanLyShopBanQuatDien.DAO;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.DTO;

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

        public static ResponseObject<OrderEntity> create(OrderEntity order)
        {
            ResponseObject<OrderEntity> res = new ResponseObject<OrderEntity>();
            res.isSuccess = false;

            if (OrderDAO.checkExist(order.code))
            {
                res.errorMessage = "Mã hóa đơn đã tồn tại";
                return res;
            }

            foreach (OrderDetailEntity orderDetail in order.orderDetails)
            {
                order.totalAmount += orderDetail.subtotal;
            }

            if (!OrderDAO.create(order))
            {
                res.errorMessage = "Không thể tạo hóa đơn";
                return res;
            }

            foreach (OrderDetailEntity orderDetail in order.orderDetails)
            {
                orderDetail.order = order;
                OrderDetailDAO.create(orderDetail);
            }

            res.isSuccess = true;
            return res;
        }

        public static ResponseObject<OrderEntity> update(OrderEntity order)
        {
            ResponseObject<OrderEntity> res = new ResponseObject<OrderEntity>();
            res.isSuccess = false;

            if (!OrderDAO.checkExist(order.code))
            {
                res.errorMessage = "Mã hóa đơn không tồn tại";
                return res;
            }
            
            order.totalAmount = 0;

            foreach (OrderDetailEntity orderDetail in order.orderDetails)
            {
                order.totalAmount += orderDetail.subtotal;
            }

            if (!OrderDAO.update(order))
            {
                res.errorMessage = "Không thể cập nhật hóa đơn";
                return res;
            }

            OrderDetailDAO.deleteByOrderCode(order.code);

            foreach (OrderDetailEntity orderDetail in order.orderDetails)
            {
                orderDetail.order = order;
                OrderDetailDAO.create(orderDetail);
            }

            res.isSuccess = true;
            return res;
        }

        public static ResponseObject<OrderEntity> delete(string code)
        {
            ResponseObject<OrderEntity> res = new ResponseObject<OrderEntity>();
            res.isSuccess = false;

            if (!OrderDAO.checkExist(code))
            {
                res.errorMessage = "Mã hóa đơn không tồn tại";
                return res;
            }

            if (!OrderDAO.delete(code))
            {
                res.errorMessage = "Không thể xóa hóa đơn";
                return res;
            }

            res.isSuccess = true;
            return res;
        }
    }
}
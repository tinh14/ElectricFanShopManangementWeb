using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.DTO;
using QuanLyShopBanQuatDien.DAO;

namespace QuanLyShopBanQuatDien.Service
{
    public class StatisticsService
    {
        public static List<RevenueByProductDTO> findRevenueByProduct(DateTime startDate, DateTime endDate)
        {
            return StatisticsDAO.findRevenueByProduct(startDate, endDate);
        }

        public static List<RevenueByCustomerDTO> findRevenueByCustomer(DateTime startDate, DateTime endDate)
        {
            return StatisticsDAO.findRevenueByCustomer(startDate, endDate);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.DTO
{
    public class ResponseObject<T>
    {
        public bool isSuccess { get; set; }
        public T data { get; set; }
        public string errorMessage { get; set; }
    }
}
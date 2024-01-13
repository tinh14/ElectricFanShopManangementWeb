using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Pages.Utils
{
    [Serializable]
    public class PageStatusManager
    {

        public enum PageMode
        {
            Create,
            Update
        }

        public PageMode mode { get; private set; }
        public string itemCode { get; private set; }

        public PageStatusManager()
        {
            // default
            mode = PageMode.Create;
        }

        public void SetUpdateMode(string itemCode)
        {
            this.mode = PageMode.Update;
            this.itemCode = itemCode;
        }

    }
}
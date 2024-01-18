using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class OperationLogDetailEntity
    {
        public Int64 id { get; set; }
        public string fieldName { get; set; }
        public string oldValue { get; set; }
        public string newValue { get; set; }
        public OperationLogEntity operationLog { get; set; }

        public OperationLogDetailEntity()
        {
            this.operationLog = new OperationLogEntity();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyShopBanQuatDien.Entities
{
    [Serializable]
    public class OperationLogEntity : LogEntity
    {
        public string action { get; set; }
        public List<OperationLogDetailEntity> operationLogDetails { get; set; }

        public OperationLogEntity()
        {
            this.operationLogDetails = new List<OperationLogDetailEntity>();
        }
    }
}
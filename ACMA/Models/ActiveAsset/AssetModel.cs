using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACMA.Models.ActiveAsset
{
    public class AssetModel
    {
        public int IdItem { get; set; }
        public int IdUnit { get; set; }
        public int IdCostCenter { get; set; }
        public int IdTag { get; set; }
        public double ItemValue { get; set; }
        public string ItemResponsable { get; set; }
        public bool ItemActive { get; set; }
    }
}
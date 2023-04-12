using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_USM_Folder.Models
{
    public class NseExport
    {
        public string ISIN { get; set; }
        public string Symbol { get; set; }
        public string Company { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public string Series { get; set; }
        public string InsertDate { get; set; }
        public int PaidUpValue { get; set; }
        public int MarketLot { get; set; }
        public int FaceValue { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public string UpdateDate { get; set; }
        public string Price { get; set; }

    }
}

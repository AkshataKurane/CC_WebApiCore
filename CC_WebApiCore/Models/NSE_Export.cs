using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC_WebApiCore.Models
{
    public class NSE_Export
    {
        [Key]
        public string ISIN { get; set; }
        public string Symbol { get; set; }
        public string Company { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
    }
}

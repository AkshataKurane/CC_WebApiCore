using CC_USM_Folder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_USM_Folder.Interfaces
{
    interface INseExport
    {
        Task<List<NseExport>> GetSecurities();
    }
}

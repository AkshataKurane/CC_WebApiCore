using CC_USM_Folder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_USM_Folder.Controllers
{
    public class NseExportController
    {
        private readonly MyDbContext _context;

        public NseExportController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NseExport>>> GetSecurities()
        {
            return await _context.NseExport.ToListAsync();
        }
    }
}

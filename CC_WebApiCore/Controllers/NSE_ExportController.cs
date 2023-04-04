using CC_WebApiCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CC_WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NSE_ExportController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        public NSE_ExportController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]//Add csv file
        [Route("AddFile")]
        public async Task<List<NSE_Export>>Import(IFormFile file)
        {
            var list = new List<NSE_Export>();
            using(var stream=new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using(var package=new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {
                        list.Add(new NSE_Export
                        {
                            ISIN = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Symbol = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Company = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Sector = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            Industry = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            Exchange = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            Currency = worksheet.Cells[row, 7].Value.ToString().Trim()
                        });
                    }
                }
            }
            return list;
        }
        
        [HttpGet]//Get all securities
        [Route("AllSecurities")]
        public IActionResult GetAllNSE()
        {
            var data = _dbContext.NSE_Export.ToList();
            return Ok(data);
        }
        [HttpPost]//Add securities 
        [Route("AddSecurity")]
        public IActionResult AddNSE(NSE_Export nSE_Export)
        {
            _dbContext.NSE_Export.Add(nSE_Export);
            _dbContext.SaveChanges();
            return Ok(nSE_Export.ISIN);
        }
        [HttpPut]//Update securities
        [Route("UpdateSecurity")]
        public IActionResult UpdateNSE(NSE_Export nSE_Export)
        {
            _dbContext.Update(nSE_Export);
            _dbContext.SaveChanges();
            return NoContent();
        }
        [HttpDelete]//Delete securities
        [Route("DeleteSecurity")]
        public IActionResult DeleteNSE(string isin)
        {
            var del = _dbContext.NSE_Export.Where(x => x.ISIN == isin).FirstOrDefault();
            if(del==null)
            {
                return NotFound();
            }
            _dbContext.NSE_Export.Remove(del);
            _dbContext.SaveChanges();
            return NoContent();
        }
        
        [HttpGet]//Get by ISIN
        [Route("GetDetailsWithISIN")]
        public async Task<ActionResult<NSE_Export>> DetailsWithISIN(string isin)
        {
            if(isin==null)
            {
                return NotFound();
            }
            var ss = await _dbContext.NSE_Export.FirstOrDefaultAsync(x => x.ISIN == isin);
            if(ss==null)
            {
                return NotFound();
            }
            return Ok(ss);
        }/*
        [HttpGet("{isin}")]
        [Route("DetailsWithISIN")]
        public async Task<ActionResult<NSE_Export>> GetDetails(int isin)
        {
            var details = await _dbContext.NSE_Export.FindAsync(isin);

            if (details == null)
            {
                return NotFound();
            }
            return details;
        }*/
    }
}

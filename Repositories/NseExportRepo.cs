using CC_USM_Folder.Interfaces;
using CC_USM_Folder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_USM_Folder.Repositories
{
    public class NseExportRepo : INseExport
    {
        private readonly MyDbContext myDbContext;
        public NseExportRepo(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        async Task<List<NseExport>> INseExport.GetSecurities()
        {
            List<NseExport> nselist = new List<NseExport>();
            var li = await myDbContext.NseExport.ToListAsync();
            foreach (NseExport em in li)
            {
                nselist.Add(new NseExport
                {
                    ISIN = em.ISIN,
                    Symbol = em.Symbol,
                    Company = em.Company,
                    Sector = em.Sector,
                    Industry = em.Industry,
                    Exchange = em.Exchange,
                    Currency = em.Currency,
                    Series = em.Series,
                    InsertDate = em.InsertDate,
                    PaidUpValue = em.PaidUpValue,
                    MarketLot = em.MarketLot,
                    FaceValue=em.FaceValue,
                    InsertUser=em.InsertUser,
                    UpdateUser=em.UpdateUser,
                    UpdateDate=em.UpdateDate,
                    Price=em.Price
                });
            }
            return nselist;
        }

    }
}

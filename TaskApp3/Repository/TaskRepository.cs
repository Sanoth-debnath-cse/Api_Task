using TaskApp3.DbContexts;
using TaskApp3.DTO;
using TaskApp3.Helper;
using TaskApp3.IRepository;
using TaskApp3.Models;
using System.Globalization;

namespace TaskApp3.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<MessageHelper> CreatePartner(string typename)
        {
            var query = _context.TblPartnerTypes.Where(x => x.PartnerTypeName != string.Empty);
            int typeid = query.Count();
            typeid = typeid + 1;
            TblPartnerType data = new TblPartnerType()
            {

                IsActive = true,
                PratnerTypeId = typeid,
                PartnerTypeName = typename,
            };
            await _context.TblPartnerTypes.AddAsync(data);
            await _context.SaveChangesAsync();
            
            return new MessageHelper()
            {
                Message = "OK"

            };
        }
        public async Task<MessageHelper> CreateItems(List<ItemDTO> obj)
        {
            var query = _context.TblItems.Where(x => x.ItemName != string.Empty);
            int itemidcount = query.Count();

            List<TblItem> items = new List<TblItem>();
            foreach (var i in obj)
            {
                itemidcount++;
                TblItem item = new()
                {
                    ItemName = i.ItemName,
                    StockQuantity = i.StockQuantity,
                    IsActive = true,
                    ItemId = itemidcount,

                };
                items.Add(item);

            }
            List<TblItem> uniquelist = items.Distinct().ToList();
            await _context.TblItems.AddRangeAsync(uniquelist);
            await _context.SaveChangesAsync();
            return new MessageHelper()
            {
                Message = "OK"

            };
        }
        public async Task<MessageHelper> EditItems(int id, ItemDTO obj)
        {
            var data = _context.TblItems.FirstOrDefault(p => p.ItemId.Equals(id));
            data.ItemId = id;
            data.StockQuantity = obj.StockQuantity+data.StockQuantity;
            data.IsActive = true;
            data.ItemName = obj.ItemName;
            _context.SaveChanges();

            return new MessageHelper()
            {
                Message = "OK"

            };
        }
        //public async Task<MessageHelper> PurchaseItems(List<PurchaseDTO> obj)
        //{
        //    var query = _context.TblPurchases.Where(x => x.IsActive!=false);
        //    int purchasecount = query.Count();
        //    List<TblPurchase> purchase = new List<TblPurchase>();
        //    foreach(var i in obj)
        //    {
        //        purchasecount++;
        //        TblPurchase purchaseitem = new() { 
        //            SupplierId= i.SupplierId,
        //            PurchaseDate=DateTime.UtcNow,
        //            IsActive=true,
        //            PurchaseId=purchasecount,
        //        };
        //        purchase.Add(purchaseitem);
        //    }
        //    await _context.TblPurchases.AddRangeAsync(purchase);
        //    await _context.SaveChangesAsync();
        //    return new MessageHelper()
        //    {
        //        Message = "OK"

        //    };

        //}
        public async Task<MessageHelper> PurchaseItems(PurchaseCommonDTO obj,int itemid)
        {
            var query = _context.TblPurchases.Where(x => x.IsActive != false);
            int purchasecount = query.Count();

            var data = _context.TblItems.FirstOrDefault(p => p.ItemId.Equals(itemid));
            if (data != null)
            {
                purchasecount++;
                TblPurchase purchaseitem = new()
                {
                    SupplierId = obj.PurchaseDetails.SupplierId,
                    PurchaseDate = DateTime.UtcNow,
                    IsActive = true,
                    PurchaseId = purchasecount,
                };
                await _context.TblPurchases.AddAsync(purchaseitem);
                await _context.SaveChangesAsync();
                var query2 = _context.TblPurchaseDetails.Where(x => x.IsActive != false);
                int detailscount = query2.Count();
                List<TblPurchaseDetail> purchase = new List<TblPurchaseDetail>();
                decimal quantity = 0;
                foreach (var i in obj.PurchaseDetailsList)
                {
                    detailscount++;
                    TblPurchaseDetail purchlist = new()
                    {
                        DetailsId = detailscount,
                        PurchaseId = purchasecount,
                        IsActive = true,
                        ItemId = data.ItemId,
                        ItemQuantity = i.ItemQuantity,
                        UnitPrice = i.UnitPrice,
                        
                    };
                    quantity = quantity + i.ItemQuantity;
                    purchase.Add(purchlist);
                }
                await _context.TblPurchaseDetails.AddRangeAsync(purchase);
                await _context.SaveChangesAsync();
                data.StockQuantity=data.StockQuantity+quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                return new MessageHelper()
                {
                    Message="Item not Available!"
                };
            }

            return new MessageHelper()
            {

              Message = "OK"

            };
        }


        public async Task<MessageHelper> SalesItem(SalesCommonDTO obj, int itemid)
        {
            var query = _context.TblSales.Where(x => x.IsActive != false);
            int salescount=query.Count();
            var data = _context.TblItems.FirstOrDefault(p => p.ItemId.Equals(itemid));
            if (data != null)
            {
                salescount++;
                TblSale sales = new()
                {
                    SalesId=salescount,
                    CustomerId=obj.sales.CustomerId,
                    IsActive=true,
                    TimeSalesDate=DateTime.UtcNow,

                };
                await _context.TblSales.AddAsync(sales);
                await _context.SaveChangesAsync();
                var query2 = _context.TblSalesDetails.Where(x => x.IsActive != false);
                int salesdetailscount = query2.Count();
                List<TblSalesDetail> salels=new List<TblSalesDetail>();
                decimal sold = 0;
                foreach (var i in obj.saleslist)
                {
                    salesdetailscount++;
                    if (i.ItemQuantity <= data.StockQuantity)
                    {
                        TblSalesDetail tblsales = new()
                        {
                            DetailsId=salesdetailscount,
                            SalesId=salescount,
                            IsActive=true,
                            ItemId=data.ItemId,
                            ItemQuantity=i.ItemQuantity,
                            UnitPrice=i.UnitPrice,
                        };
                        sold=sold+i.ItemQuantity;
                        salels.Add(tblsales);
                    }
                    else
                    {
                        return new MessageHelper()
                        {
                            Message = "Item not Available!"
                        };
                    }
                }
                await _context.TblSalesDetails.AddRangeAsync(salels);
                await _context.SaveChangesAsync();
                data.StockQuantity = data.StockQuantity -sold;
                await _context.SaveChangesAsync();
            }
            else
            {
                return new MessageHelper()
                {
                    Message = "Item not Available!"
                };
            }

            return new MessageHelper()
            {

                Message = "OK"

            };
        }



        public IEnumerable<PurchaseShowDTO> PurchaseReport(int itemid)
        {
            IEnumerable<PurchaseShowDTO> purchaseRepost = (from p in _context.TblPurchases
                                                           join pd in _context.TblPurchaseDetails on p.PurchaseId equals pd.PurchaseId
                                                           join i in _context.TblItems on pd.ItemId equals i.ItemId
                                                           where (pd.IsActive.Equals(true)) && (pd.ItemId==itemid)
                                                           select new PurchaseShowDTO
                                                           {
                                                              ItemId=i.ItemId,
                                                              PurchaseId=pd.PurchaseId,
                                                              SupplierId=p.SupplierId,
                                                              PurchaseDate=p.PurchaseDate,
                                                              DetailsId=pd.DetailsId,
                                                              ItemQuantity=pd.ItemQuantity,
                                                              UnitPrice=pd.UnitPrice,
                                                              totalPurchaseAmount = pd.UnitPrice * pd.ItemQuantity,
                                                              StockQuantity=i.StockQuantity,
                                                           });

            return purchaseRepost;
        }



        public IEnumerable<SalesShowDTO> SalesReport(int salesid, DateTime fromdate, DateTime todate)
        {
            IEnumerable<SalesShowDTO> SalesReport = (from s in _context.TblSales
                                                     join sd in _context.TblSalesDetails on s.SalesId equals sd.SalesId
                                                     join i in _context.TblItems on sd.ItemId equals i.ItemId
                                                     where (s.IsActive.Equals(true)) && (s.TimeSalesDate.Date >= fromdate.Date && s.TimeSalesDate.Date <= todate.Date)
                                                     && (sd.SalesId==salesid)
                                                     select new SalesShowDTO
                                                     {
                                                         ItemId=i.ItemId,
                                                         SalesId=s.SalesId,
                                                         CustomerId=s.CustomerId,
                                                         TimeSalesDate=s.TimeSalesDate,
                                                         StockQuantity=i.StockQuantity,
                                                         TotalSalesAmount=sd.ItemQuantity*sd.UnitPrice,
                                                         ItemQuantity=sd.ItemQuantity,
                                                         UnitPrice=sd.UnitPrice,
                                                     });
            return SalesReport;
        }

        public IEnumerable<SalesShowDTO> SalesReportMonthly(int salesid)
        {
            IEnumerable<SalesShowDTO> SalesReport = (from s in _context.TblSales
                                                     join sd in _context.TblSalesDetails on s.SalesId equals sd.SalesId
                                                     join i in _context.TblItems on sd.ItemId equals i.ItemId
                                                     where (s.IsActive.Equals(true)) && (s.TimeSalesDate.Month==(DateTime.Today.Month)-1)
                                                     && (sd.SalesId == salesid)
                                                     select new SalesShowDTO
                                                     {
                                                         ItemId = i.ItemId,
                                                         SalesId = s.SalesId,
                                                         CustomerId = s.CustomerId,
                                                         TimeSalesDate = s.TimeSalesDate,
                                                         StockQuantity = i.StockQuantity,
                                                         TotalSalesAmount = sd.ItemQuantity * sd.UnitPrice,
                                                         ItemQuantity = sd.ItemQuantity,
                                                         UnitPrice = sd.UnitPrice,
                                                     });
            return SalesReport;
        }



        public IEnumerable<purchaseVSsalesReport> purchaseVSsalesReports(int itemid)
        {
            IEnumerable<purchaseVSsalesReport> pVSs = (from pd in _context.TblPurchaseDetails
                                                       join sd in _context.TblSalesDetails on pd.ItemId equals sd.ItemId
                                                       join i in _context.TblItems on sd.ItemId equals i.ItemId
                                                       join p in _context.TblPurchases on pd.PurchaseId equals p.PurchaseId
                                                       join s in _context.TblSales on sd.SalesId equals s.SalesId
                                                       where (sd.IsActive.Equals(true) && pd.IsActive.Equals(true)) && (p.PurchaseDate.Day.Equals(DateTime.UtcNow.Day))
                                                       select new purchaseVSsalesReport
                                                       {
                                                           ItemId=i.ItemId,
                                                           TtotalPurchaseAmount=pd.UnitPrice*pd.ItemQuantity,
                                                           TotalSalesAmount=sd.ItemQuantity * sd.UnitPrice,
                                                           StockQuantity=i.StockQuantity,
                                                       }
                                                      );
            return pVSs;
        }

        public IEnumerable<FinalReportDTO> FinalReport(int itemid)
        {
            IEnumerable<FinalReportDTO> FinalReport = (from pd in _context.TblPurchaseDetails
                                                       join sd in _context.TblSalesDetails on pd.ItemId equals sd.ItemId
                                                       join i in _context.TblItems on sd.ItemId equals i.ItemId
                                                       join p in _context.TblPurchases on pd.PurchaseId equals p.PurchaseId
                                                       join s in _context.TblSales on sd.SalesId equals s.SalesId
                                                       where (i.IsActive.Equals(true)) && pd.ItemId.Equals(itemid) && sd.ItemId.Equals(itemid) && i.ItemId.Equals(itemid)
                                                      select new FinalReportDTO
                                                      {
                                                            month=s.TimeSalesDate.ToString("MMMM", CultureInfo.InvariantCulture),
                                                            year=s.TimeSalesDate.ToString("yyyy", CultureInfo.InvariantCulture),
                                                            total_purchase_amount=pd.UnitPrice*pd.ItemQuantity,
                                                            total_sales_amount=sd.ItemQuantity * sd.UnitPrice,
                                                            proftORloss=(sd.ItemQuantity * sd.UnitPrice)-(pd.UnitPrice * pd.ItemQuantity),
                                                       
                                                      }
                                                      );
            return FinalReport;
        }
    }

}

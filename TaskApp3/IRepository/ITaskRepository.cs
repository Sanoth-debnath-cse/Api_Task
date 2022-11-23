using TaskApp3.DTO;
using TaskApp3.Helper;

namespace TaskApp3.IRepository
{
    public interface ITaskRepository
    {
        public Task<MessageHelper> CreatePartner(string typename);
        public Task<MessageHelper> CreateItems(List<ItemDTO> obj);

        public Task<MessageHelper> EditItems(int id, ItemDTO obj);
        public Task<MessageHelper> PurchaseItems(PurchaseCommonDTO obj,int itemid);
        public Task<MessageHelper> SalesItem(SalesCommonDTO obj,int itemid);
        
        public IEnumerable<PurchaseShowDTO> PurchaseReport(int itemid);
        public IEnumerable<SalesShowDTO> SalesReport(int salesid, DateTime fromdate, DateTime todate);
        public IEnumerable<SalesShowDTO> SalesReportMonthly(int salesid);

        public IEnumerable<purchaseVSsalesReport> purchaseVSsalesReports (int itemid);
        public IEnumerable<FinalReportDTO> FinalReport (int itemid);


    }
}

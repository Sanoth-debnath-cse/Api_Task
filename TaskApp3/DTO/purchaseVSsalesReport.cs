namespace TaskApp3.DTO
{
    public class purchaseVSsalesReport
    {
        public int ItemId { get; set; }

        public decimal TtotalPurchaseAmount { get; set; }
        public decimal TotalSalesAmount { get; set; }
        public decimal? StockQuantity { get; set; }

    }
}

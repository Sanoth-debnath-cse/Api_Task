namespace TaskApp3.DTO
{
    public class SalesShowDTO
    {
        public int ItemId { get; set; }
        public int SalesId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TimeSalesDate { get; set; }
        public decimal ItemQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalSalesAmount { get; set; }
        public decimal? StockQuantity { get; set; }
    }
}

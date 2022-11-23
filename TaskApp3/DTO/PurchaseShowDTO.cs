namespace TaskApp3.DTO
{
    public class PurchaseShowDTO
    {
        public int ItemId { get; set; }
        public int SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int DetailsId { get; set; }
        public int PurchaseId { get; set; }
        public decimal ItemQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal totalPurchaseAmount { get; set; }
        public decimal? StockQuantity { get; set; }
    }
}

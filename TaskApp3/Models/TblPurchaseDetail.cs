using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskApp3.Models
{
    [Table("tblPurchaseDetails")]
    public partial class TblPurchaseDetail
    {
        [Key]
        public int DetailsId { get; set; }
        public int PurchaseId { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal ItemQuantity { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal UnitPrice { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskApp3.Models
{
    [Table("tblPurchase")]
    public partial class TblPurchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int SupplierId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PurchaseDate { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskApp3.Models
{
 
    [Table("tblItem")]
    public partial class TblItem
    {
        [Key]
        public int ItemId { get; set; }
        [StringLength(100)]
        public string? ItemName { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? StockQuantity { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}

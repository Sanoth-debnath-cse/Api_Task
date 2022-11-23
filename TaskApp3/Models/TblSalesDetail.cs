using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskApp3.Models
{
    [Table("tblSalesDetails")]
    public partial class TblSalesDetail
    {
        [Key]
        public int DetailsId { get; set; }
        public int SalesId { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal ItemQuantity { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal UnitPrice { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}

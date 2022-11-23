using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskApp3.Models
{
    [Table("tblSales")]
    public partial class TblSale
    {
        [Key]
        public int SalesId { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TimeSalesDate { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}

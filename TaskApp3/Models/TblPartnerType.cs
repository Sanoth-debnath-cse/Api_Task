using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskApp3.Models
{
    [Table("tblPartnerType")]
    public partial class TblPartnerType
    {
        [Key]
        public int PratnerTypeId { get; set; }
        [StringLength(100)]
        public string? PartnerTypeName { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskApp3.Models
{
    [Table("tblPartner")]
    public partial class TblPartner
    {
        [Key]
        public int PartnerId { get; set; }
        [StringLength(100)]
        public string? PartnerName { get; set; }
        public int PartnerTypeId { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}

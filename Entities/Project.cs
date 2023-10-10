﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClsOutDocDeliveryCtrl.Entities;

public class Project
{
    public int ProjectId { get; set; }
    [MaxLength(500)]
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime PlannedEndDate { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ContractValue { get; set; }
    [MaxLength(50)]
    public string Currency { get; set; }
    [MaxLength(100)]
    public string OwnerName { get; set; }
    [MaxLength(100)]
    public string ConsultantName { get; set; }
    [MaxLength(100)]
    public string ContractorName { get; set; }
    public int ConsultantReviewTimeInDays { get; set; }

    // Navigation property for many-to-many relationship with documents
    public ICollection<Document> Documents { get; set; } = new HashSet<Document>();
}

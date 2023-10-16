using System.ComponentModel.DataAnnotations;
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
    public ICollection<Document> Documents { get; set; } = new HashSet<Document>() {
        new Document { Name = "As-built Drawings", Description = "As-built Drawings Description"},  
        new Document { Name = "Operation & Maintenance Manual", Description = "Operation & Maintenance Manual Description"},
        new Document { Name = "Equipment Warranties", Description = "Equipment Warranties Description"},
        new Document { Name = "Equipment Data sheets", Description = "Equipment Data sheets Description"},
        new Document { Name = "Test results reports", Description = "Test results reports Description"},  
        new Document { Name = "Commissioning reports", Description = "Description, Commissioning reports"},  
        new Document { Name = "Record of training for facility team", Description = "Record of training for facility team Description"},  
        new Document { Name = "Documentation for Variations,RFIs,…", Description = "Documentation for Variations,RFIs,… Description"},  
        new Document { Name = "List of spare parts", Description = "List of spare parts Description"},  
        new Document { Name = "List of contacts for suppliers and subcontractors", Description = "List of contacts for suppliers and subcontractors Description"},  
        new Document { Name = "Communication plan for the year of gurantee", Description = "Communication plan for the year of gurantee Description"}
    };
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClsOutDocDeliveryCtrl.Entities;

public class Document
{

    public int DocumentId { get; set; }
    [MaxLength(500)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int? RcmdDeadlineBeforeHandover { get; set; }
    public int? RcmdDeadlineAfterHandover { get; set; }
    public DateTime? ActFirstCTRSubmitDeadline { get; set; }
    public DateTime? ActFirstCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public DeliveryStatus FirstCTRSubmitStatus { get; set; } = DeliveryStatus.Pending;
    public DateTime? ExpFirstConsultRspDate { get; set; }
    public DateTime? ActFirstConsultRspDate { get; set; }
    [MaxLength(50)]
    public SubmittalCode? ConsultFirstRspCode { get; set; }
    [MaxLength(50)]
    public ResponseStatus ConsultFirstRspStatus { get; set; } = ResponseStatus.Pending;



    public DateTime? ActSecondCTRSubmitDeadline { get; set; }
    public DateTime? ActSecondCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public DeliveryStatus SecondCTRSubmitStatus { get; set; } = DeliveryStatus.Pending;
    public DateTime? ExpSecondConsultRspDate { get; set; }
    public DateTime? ActSecondConsultRspDate { get; set; }
    [MaxLength(50)]
    public SubmittalCode? ConsultSecondRspCode { get; set; }
    [MaxLength(50)]
    public ResponseStatus ConsultSecondRspStatus { get; set; } = ResponseStatus.Pending;




    public DateTime? ActThirdCTRSubmitDeadline { get; set; }
    public DateTime? ActThirdCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public DeliveryStatus ThirdCTRSubmitStatus { get; set; } = DeliveryStatus.Pending;
    public DateTime? ExpThirdConsultRspDate { get; set; }
    public DateTime? ActThirdConsultRspDate { get; set; }
    [MaxLength(50)]
    public SubmittalCode? ConsultThirdRspCode { get; set; }
    [MaxLength(50)]
    public ResponseStatus ConsultThirdRspStatus { get; set; } = ResponseStatus.Pending;




    public DateTime? ActOwnerSubmitDate { get; set; }
    [MaxLength(50)]
    public DeliveryStatus OwnerSubmitStatus { get; set; } = DeliveryStatus.Pending;
    [MaxLength(100)]
    public string? OwnerSubmitFormat { get; set; }
    [MaxLength(500)]
    public string? StoragePlace { get; set; }
    [MaxLength(100)]
    public string? ReceivedBy { get; set; }
    [Column(TypeName = "decimal(5, 4)")]
    public decimal? Retention { get; set; }
    [Column(TypeName = "decimal(5, 4)")]
    public decimal? Deduction { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }

}



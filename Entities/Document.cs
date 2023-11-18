using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClsOutDocDeliveryCtrl.Entities;

public class Document
{

    public int DocumentId { get; set; }
    [MaxLength(500)]
    public string Name { get; set; }
    public string Description { get; set; }
    public SendCopy SendCopyToOwner { get; set; } = SendCopy.No;
    public int? RcmdDeadlineBeforeHandover { get; set; }
    public int? RcmdDeadlineAfterHandover { get; set; }
    public DateTime? ActFirstCTRSubmitDeadline { get; set; }
    public DateTime? ActFirstCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public DeliveryStatus FirstCTRSubmitStatus { get; set; } = DeliveryStatus.NotSet;
    public DateTime? ExpFirstConsultRspDate { get; set; }
    public DateTime? ActFirstConsultRspDate { get; set; }
    [MaxLength(50)]
    public ResponseCode? ConsultFirstRspCode { get; set; } = ResponseCode.NotSet;
    [MaxLength(50)]
    public ResponseStatus ConsultFirstRspStatus { get; set; } = ResponseStatus.NotSet;



    public DateTime? ActSecondCTRSubmitDeadline { get; set; }
    public DateTime? ActSecondCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public DeliveryStatus SecondCTRSubmitStatus { get; set; } = DeliveryStatus.NotSet;
    public DateTime? ExpSecondConsultRspDate { get; set; }
    public DateTime? ActSecondConsultRspDate { get; set; }
    [MaxLength(50)]
    public ResponseCode? ConsultSecondRspCode { get; set; } = ResponseCode.NotSet;
    [MaxLength(50)]
    public ResponseStatus ConsultSecondRspStatus { get; set; } = ResponseStatus.NotSet;




    public DateTime? ActThirdCTRSubmitDeadline { get; set; }
    public DateTime? ActThirdCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public DeliveryStatus ThirdCTRSubmitStatus { get; set; } = DeliveryStatus.NotSet;
    public DateTime? ExpThirdConsultRspDate { get; set; }
    public DateTime? ActThirdConsultRspDate { get; set; }
    [MaxLength(50)]
    public ResponseCode? ConsultThirdRspCode { get; set; } = ResponseCode.NotSet;
    [MaxLength(50)]
    public ResponseStatus ConsultThirdRspStatus { get; set; } = ResponseStatus.NotSet;




    public DateTime? ActOwnerSubmitDate { get; set; }
    [MaxLength(50)]
    public DeliveryStatus OwnerSubmitStatus { get; set; } = DeliveryStatus.NotSet;
    [MaxLength(100)]
    public SubmitalFormat OwnerSubmitFormat { get; set; } = SubmitalFormat.NotSet;
    [MaxLength(500)]
    public string? StoragePlace { get; set; }
    [MaxLength(500)]
    public string? SoftCopyLink { get; set; }
    [MaxLength(500)]
    public string? SoftCopyFormat { get; set; }
    [MaxLength(1000)]
    public string? Comment { get; set; }
    [MaxLength(100)]
    public string? ReceivedBy { get; set; }
    [Column(TypeName = "decimal(5, 4)")]
    public decimal? Retention { get; set; }
    [Column(TypeName = "decimal(5, 4)")]
    public decimal? Deduction { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }

}



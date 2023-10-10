using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClsOutDocDeliveryCtrl.Entities;

public class Document
{

    public int DocumentId { get; set; }
    [MaxLength (500)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int RcmdDeadlineBeforeHandover { get; set; }
    public int RcmdDeadlineAfterHandover { get; set; }


    public DateTime ActFirstCTRSubmitDeadline { get; set; }
    public DateTime ActFirstCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public string FirstCTRSubmitStatus { get; set; }
    public DateTime ExpFirstConsultRspDate { get; set; }
    public DateTime ActFirstConsultRspDate { get; set; }
    [MaxLength(50)]
    public string ConsultFirstRspCode { get; set; }
    [MaxLength(50)]
    public string ConsultFirstRspStatus { get; set; }



    public DateTime? ActSecondCTRSubmitDeadline { get; set; }
    public DateTime? ActSecondCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public string? SecondCTRSubmitStatus { get; set; }
    public DateTime? ExpSecondConsultRspDate { get; set; }
    public DateTime? ActSecondConsultRspDate { get; set; }
    [MaxLength(50)]
    public string? ConsultSecondRspCode { get; set; }
    [MaxLength(50)]
    public string? ConsultSecondRspStatus { get; set; }




    public DateTime? ActThirdCTRSubmitDeadline { get; set; }
    public DateTime? ActThirdCTRSubmitDeliveryDate { get; set; }
    [MaxLength(50)]
    public string? ThirdCTRSubmitStatus { get; set; }
    public DateTime? ExpThirdConsultRspDate { get; set; }
    public DateTime? ActThirdConsultRspDate { get; set; }
    [MaxLength(50)]
    public string? ConsultThirdRspCode { get; set; }
    [MaxLength(50)]
    public string? ConsultThirdRspStatus { get; set; }




    public DateTime ActOwnerSubmitDate { get; set; }
    [MaxLength(50)]
    public string OwnerSubmitStatus { get; set; }
    [MaxLength(100)]
    public string OwnerSubmitFormat { get; set; }
    [MaxLength(500)]
    public string StoragePlace { get; set; }
    [MaxLength(100)]
    public string ReceivedBy { get; set; }
    [Column(TypeName = "decimal(5, 4)")]
    public decimal TotalRetention { get; set; }
    [Column(TypeName = "decimal(5, 4)")]
    public decimal TotalDeduction { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }

}
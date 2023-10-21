namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum SubmittalCode
    {
        Approved,
        ApprovedAsSubmitted,
        ResubmitAsPerNoted,
    }
    public static class SubmittalCodeExtensions
    {
        public static string ToDescriptionString(this SubmittalCode status)
        {
            switch (status)
            {
                case SubmittalCode.Approved:
                    return "Approved";
                case SubmittalCode.ApprovedAsSubmitted:
                    return "Approved as submitted";
                case SubmittalCode.ResubmitAsPerNoted:
                    return "Resubmit as per noted";
                default:
                    return string.Empty;
            }
        }
    }
}

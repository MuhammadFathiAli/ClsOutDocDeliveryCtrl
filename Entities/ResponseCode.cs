namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum ResponseCode
    {
        NotSet,
        Approved,
        ApprovedAsSubmitted,
        ResubmitAsPerNoted,
    }
    public static class SubmittalCodeExtensions
    {
        public static string ToDescriptionString(this ResponseCode status)
        {
            switch (status)
            {
                case ResponseCode.NotSet:
                    return "Not Set";
                case ResponseCode.Approved:
                    return "Approved";
                case ResponseCode.ApprovedAsSubmitted:
                    return "Approved as submitted";
                case ResponseCode.ResubmitAsPerNoted:
                    return "Resubmit as per noted";
                default:
                    return string.Empty;
            }
        }
    }
}

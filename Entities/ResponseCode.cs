namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum ResponseCode
    {
        NotSet,
        Approved,
        ResubmitAsPerNoted,
        Rejected
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
                case ResponseCode.Rejected:
                    return "Rejected";
                case ResponseCode.ResubmitAsPerNoted:
                    return "Resubmit as per noted";
                default:
                    return string.Empty;
            }
        }
    }
}

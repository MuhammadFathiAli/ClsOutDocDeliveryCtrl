namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum ResponseStatus
    {
        Late,
        Pending,
        RespondedOnTime,
        RespondedLate
    }
    public static class ResponseStatusExtensions
    {
        public static string ToDescriptionString(this ResponseStatus status)
        {
            switch (status)
            {
                case ResponseStatus.Late:
                    return "Late";
                case ResponseStatus.Pending:
                    return "Pending";
                case ResponseStatus.RespondedOnTime:
                    return "Responded on Time";
                case ResponseStatus.RespondedLate:
                    return "Responded Late";
                default:
                    return string.Empty;
            }
        }
    }
}

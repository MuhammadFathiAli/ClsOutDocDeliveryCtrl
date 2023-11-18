namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum ResponseStatus
    {
        NotSet,
        Late,
        Required,
        RespondedOnTime,
        RespondedLate
    }
    public static class ResponseStatusExtensions
    {
        public static string ToDescriptionString(this ResponseStatus status)
        {
            switch (status)
            {
                case ResponseStatus.NotSet:
                    return "Not Set";
                case ResponseStatus.Late:
                    return "Late";
                case ResponseStatus.Required:
                    return "Required";
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

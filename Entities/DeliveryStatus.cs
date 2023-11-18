namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum DeliveryStatus
    {
        NotSet,
        Late,
        Required,
        DeliveredOnTime,
        DeliveredLate
    }
    public static class DeliveryStatusExtensions
    {
        public static string ToDescriptionString(this DeliveryStatus status)
        {
            switch (status)
            {
                case DeliveryStatus.NotSet:
                    return "Not Set";
                case DeliveryStatus.Late:
                    return "Late";
                case DeliveryStatus.Required:
                    return "Required";
                case DeliveryStatus.DeliveredOnTime:
                    return "Delivered on Time";
                case DeliveryStatus.DeliveredLate:
                    return "Delivered Late";
                default:
                    return string.Empty;
            }
        }
    }
}

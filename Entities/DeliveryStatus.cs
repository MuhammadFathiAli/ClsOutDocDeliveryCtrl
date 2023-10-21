namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum DeliveryStatus
    {
        NotSet,
        Late,
        Pending,
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
                case DeliveryStatus.Pending:
                    return "Pending";
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

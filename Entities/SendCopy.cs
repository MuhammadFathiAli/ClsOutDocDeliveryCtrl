namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum SendCopy
    {
        Yes,
        No
    }
    public static class SendCopyExtensions
    {
        public static string ToDescriptionString(this SendCopy sendCopy)
        {
            switch (sendCopy)
            {
                case SendCopy.Yes:
                    return "Yes";
                case SendCopy.No:
                    return "--";
                default:
                    return string.Empty;
            }
        }
    }
}

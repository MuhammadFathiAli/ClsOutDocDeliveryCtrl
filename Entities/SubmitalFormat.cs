namespace ClsOutDocDeliveryCtrl.Entities
{
    public enum SubmitalFormat
    {
        NotSet,
        SoftCopy,
        HardCopy,
        Both
    }
    public static class SubmitalFormatExtensions
    {
        public static string ToDescriptionString(this SubmitalFormat status)
        {
            switch (status)
            {
                case SubmitalFormat.NotSet:
                    return "Not Set";
                case SubmitalFormat.SoftCopy:
                    return "Soft Copy";
                case SubmitalFormat.HardCopy:
                    return "Hard Copy";
                case SubmitalFormat.Both:
                    return "Both (Hard - Soft) Copies";
                default:
                    return string.Empty;
            }
        }
    }
}

namespace Base
{
    public class Constant
    {
        public enum Status
        {
            Submit = 1,
            Confirmed = 2,
            Sent = 3
        };

        public enum Province
        {
            BC = 1,
            MB = 2,
        };

        public struct Bookmark
        {
            public static string WaitforConfirmation = "WaitForConfirmation";
            public static string WaitforSending = "WaitForSending";
        }

        public struct AppSettingKeys
        {
            public static string Organization = "Organization";
        }

    }
}

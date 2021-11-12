namespace GlobalSqa.Test.Helpers
{
    public static class HelpersExtension
    {
        public static string ToFriendlyName(this string text)
        {
            return text.Replace("(", " - ").Replace(")", "").Replace("\"", "");
        }
    }
}

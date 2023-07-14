namespace RainFramework.Helper
{
    public static class BooleanExtension
    {
        /// <summary>
        /// bool convert to success or failed string
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <returns></returns>
        public static string ToSuccessOrFailed(this bool isSuccess)
        {
            return isSuccess ? "success" : " failed";
        }
    }
}
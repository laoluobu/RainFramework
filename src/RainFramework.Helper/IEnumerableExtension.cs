namespace RainFramework.Helper
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// 如果序列中任意一个值为true，则返回true
        /// </summary>
        /// <param name="bools"></param>
        /// <returns></returns>
        public static bool AnyTrue(this IEnumerable<bool> bools)
        {
            return bools.Any(s => s);
        }


        /// <summary>
        /// 如果序列中所有的值为true时，则返回true
        /// </summary>
        /// <param name="bools"></param>
        /// <returns></returns>
        public static bool AllTrue(this IEnumerable<bool> bools)
        {
            return bools.Count(s => s) == bools.Count();
        }

        /// <summary>
        /// 如果序列中所有的值为false时，则返回true
        /// </summary>
        /// <param name="bools"></param>
        /// <returns></returns>
        public static bool AllFalse(this IEnumerable<bool> bools)
        {
            return !bools.Any(s => s);
        }


        /// <summary>
        /// 如果序列中任意一个值为false，则返回true
        /// </summary>
        /// <param name="bools"></param>
        /// <returns></returns>
        public static bool AnyFalse(this IEnumerable<bool> bools)
        {
            return bools.Any(s => !s);
        }
    }
}

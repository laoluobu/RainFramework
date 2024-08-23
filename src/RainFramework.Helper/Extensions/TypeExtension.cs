namespace RainFramework.Helper.Extensions
{
    public static class TypeExtension
    {
        /// <summary>
        /// 是否是Enume List
        /// </summary>
        /// <param name="type"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static bool IsListOfEnum(this Type type, out Type? enumType)
        {
            if (type.IsList())
            {
                Type[] genericArguments = type.GetGenericArguments();

                if (genericArguments.Length == 1 && genericArguments[0].IsEnum)
                {
                    enumType = genericArguments[0];
                    return true;
                }
            }
            enumType = null;
            return false;
        }

        /// <summary>
        /// 是否是List
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsList(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 判断是自定义类型 ，即用户创建的类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsCustomType(this Type type)
        {

            if (type.IsPrimitive) // 判断是否为原始类型，如 int, bool 等
                return false;

            if (type == typeof(string) ||
                type == typeof(decimal) ||
                type == typeof(DateTime) ||
                type.IsEnum)
                return false;
            return true;
        }

        /// <summary>
        /// 是否是自定义类型 List
        /// </summary>
        /// <param name="type"></param>
        /// <param name="genericType"></param>
        /// <returns></returns>
        public static bool IsListOfCustomType(this Type type, out Type? genericType)
        {
            if (type.IsList())
            {
                Type[] genericArguments = type.GetGenericArguments();
                genericType = genericArguments[0];
                if (genericArguments.Length == 1 && genericType.IsCustomType())
                {
                    return true;
                }
            }
            genericType = null;
            return false;
        }

    }

}

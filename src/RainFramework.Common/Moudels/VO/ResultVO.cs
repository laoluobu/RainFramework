namespace RainFramework.Common.Moudels.VO
{
    /// <summary>
    /// Result Tool
    /// </summary>
    public class HttpResult
    {
        /// <summary>
        /// 成功代码
        /// </summary>
        public const int SUCCESS = 20000;

        /// <summary>
        /// 失败代码
        /// </summary>
        public const int FAIL = 50000;


        /// <summary>
        /// 结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ResultVO<T> : ResultVO
        {
            /// <summary>
            /// 数据
            /// </summary>
            public T? Data { get; set; }
        }

        /// <summary>
        /// 结果
        /// </summary>
        public class ResultVO
        {
            /// <summary>
            /// Code
            /// </summary>
            public int Code { get; set; }

            /// <summary>
            /// Messgae
            /// </summary>
            public string? Message { get; set; }
        }

        /// <summary>
        /// 返回成功结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultVO<T> Success<T>(T? data)
        {
            return new ResultVO<T>
            {
                Data = data,
                Code = SUCCESS,
                Message = "Success"
            };
        }

        /// <summary>
        /// 返回成功结果
        /// </summary>
        /// <returns></returns>
        public static ResultVO Success()
        {
            return new ResultVO
            {
                Code = SUCCESS,
                Message = "Success"
            };
        }

        /// <summary>
        /// 返回失败结果
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static ResultVO Fail(Exception exception)
        {
            return Fail(exception.Message);
        }

        /// <summary>
        /// 返回失败结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResultVO Fail(string msg)
        {
            return new ResultVO
            {
                Code = FAIL,
                Message = msg
            };
        }

        /// <summary>
        /// 返回Not Found
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResultVO NotFound(string msg)
        {
            return new ResultVO
            {
                Code = 40001,
                Message = msg
            };
        }
    }
}
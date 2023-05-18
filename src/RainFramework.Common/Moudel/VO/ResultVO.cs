namespace RainFramework.Common.Moudel.VO
{
    public class ResultTool
    {
        public class ResultVO<T>
        {
            public T? Data { get; set; }

            public int Code { get; set; }

            public string? Message { get; set; }
        }

        public class ResultVO
        {
            public object? Data { get; set; }

            public int Code { get; set; }

            public string? Message { get; set; }
        }

        public static ResultVO<T> Success<T>(T? data)
        {
            return new ResultVO<T>
            {
                Data = data,
                Code = 20000,
                Message = "Success"
            };
        }

        public static ResultVO Success()
        {
            return new ResultVO
            {
                Data = null,
                Code = 20000,
                Message = "Success"
            };
        }

        public static ResultVO Fail(Exception exception)
        {
            return Fail(exception.Message);
        }

        public static ResultVO Fail(string msg)
        {
            return new ResultVO
            {
                Data = null,
                Code = 50000,
                Message = msg
            };
        }


        public static ResultVO NotFound(string msg)
        {
            return new ResultVO
            {
                Data = null,
                Code = 40001,
                Message = msg
            };
        }

        public static ResultVO<string> TFail(string msg)
        {
            return new ResultVO<string>
            {
                Data = default,
                Code = 50000,
                Message = msg
            };
        }
    }
}
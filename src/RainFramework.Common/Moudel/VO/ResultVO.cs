namespace RainFramework.Common.Moudel.VO
{
    public class ResultTool
    {
        public const int SUCCESS = 20000;
        public const int FAIL = 50000;

        public class ResultVO<T>
        {
            public T? Data { get; set; }

            public int Code { get; set; }

            public string? Message { get; set; }
        }

        public class ResultVO
        {
            public int Code { get; set; }

            public string? Message { get; set; }
        }

        public static ResultVO<T> Success<T>(T? data)
        {
            return new ResultVO<T>
            {
                Data = data,
                Code = SUCCESS,
                Message = "Success"
            };
        }

        public static ResultVO Success()
        {
            return new ResultVO
            {
                Code = SUCCESS,
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
                Code = FAIL,
                Message = msg
            };
        }

        public static ResultVO NotFound(string msg)
        {
            return new ResultVO
            {
                Code = 40001,
                Message = msg
            };
        }

        public static ResultVO<string> TFail(string msg)
        {
            return new ResultVO<string>
            {
                Data = default,
                Code = FAIL,
                Message = msg
            };
        }
    }
}
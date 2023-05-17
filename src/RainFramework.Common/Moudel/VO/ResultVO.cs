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

        public static ResultVO<T> Ok<T>(T? data)
        {
            return new ResultVO<T>
            {
                Data = data,
                Code = 20000,
                Message = "Success"
            };
        }

        public static ResultVO<bool> Ok()
        {
            return new ResultVO<bool>
            {
                Data = true,
                Code = 20000,
                Message = "Success"
            };
        }

        public static ResultVO<bool> Fail(Exception exception)
        {
            return Fail(exception.Message);
        }

        public static ResultVO<bool> Fail(string msg)
        {
            return new ResultVO<bool>
            {
                Data = false,
                Code = 40000,
                Message = msg
            };
        }
    }
}
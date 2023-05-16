namespace RainFramework.Common.Moudel.VO
{
    public class ResultVO<T>
    {
        public static ResultVO<T> Failed => Fail();

        public static ResultVO<bool> Successed => ResultVO<bool>.Ok(true);

        public T? Data { get; set; }

        public int Code { get; set; }

        public string? Message { get; set; }

        public static ResultVO<T> Ok(T? data)
        {
            return new ResultVO<T>
            {
                Data = data,
                Code = 20000,
                Message = "Success"
            };
        }

        public static ResultVO<T> Ok()
        {
            return new ResultVO<T>
            {
                Data = default,
                Code = 20000,
                Message = "Success"
            };
        }

        public static ResultVO<T> Fail(Exception exception)
        {
            return Fail(exception.Message);
        }

        public static ResultVO<T2> From<T2>(T2 d) where T2 : class
        {
            return d != null ? ResultVO<T2>.Ok(d) : ResultVO<T2>.Failed;
        }

        public static ResultVO<T> Fail(string msg = "")
        {
            return new ResultVO<T>
            {
                Data = default,
                Code = 40000,
                Message = msg
            };
        }

        public static ResultVO<bool> From(bool b)
        {
            return b ? ResultVO<bool>.Successed : ResultVO<bool>.Failed;
        }
    }
}
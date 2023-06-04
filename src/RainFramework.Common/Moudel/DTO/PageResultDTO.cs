namespace RainFramework.Common.Moudel.DTO
{
    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public record PageResultDTO<T>(List<T>? Datas, int? Count);
}
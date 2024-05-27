namespace RainFramework.Model.Entities
{
    /// <summary>
    /// UI 设置
    /// </summary>
    public class AppConfig : EntityBase
    {
        /// <summary>
        /// UI是否显示Tags
        /// </summary>
        public bool IsShowTagsView { get; set; }

        /// <summary>
        /// UI 是否固定Header
        /// </summary>
        public bool IsFixedHeader { get; set; }

        /// <summary>
        /// 是否显示Logo
        /// </summary>
        public bool IsShowLogo { get; set; }
    }
}
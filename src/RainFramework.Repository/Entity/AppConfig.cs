﻿using RainFramework.Common.Base;

namespace RainFramework.Repository.Entity
{
    /// <summary>
    /// UI 设置
    /// </summary>
    public class AppConfig : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

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
using System.Windows.Markup;

namespace RainWPF.Extension
{
    /// <summary>
    /// 把Enum转换为可Binding的数据
    /// </summary>
    public class EnumBindingExtension : MarkupExtension
    {
        private Type _enumeType;

        public EnumBindingExtension(Type enumeType)
        {
            if (enumeType == null || !enumeType.IsEnum)
            {
                throw new ArgumentException(nameof(enumeType));
            }
            _enumeType = enumeType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(_enumeType);
        }
    }
}
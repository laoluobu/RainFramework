namespace RainDesktop.ViewModel
{
    public class MenusVM
    {
        public string Name { get; set; } = null!;

        public string Path { get; set; } = null!;

        public bool IsHidden { get; set; }

        public MenuMetaVM? MenuMeta { get; set; }
    }
}
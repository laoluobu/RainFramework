using Stocker.Helper.Dialog;

namespace RainWPF.Abstractions
{
    public interface IRWPF
    {
        IServiceProvider ServicesProvider { get; }

        IDialogService DialogService { get; }

        void Run();
    }
}
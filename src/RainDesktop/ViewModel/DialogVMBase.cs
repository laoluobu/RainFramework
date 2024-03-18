using CommunityToolkit.Mvvm.ComponentModel;

namespace RainDesktop.ViewModel
{
    public partial class DialogVMBase : ViewModelBase
    {
        [ObservableProperty]
        private bool? dialogResult;
    }
}
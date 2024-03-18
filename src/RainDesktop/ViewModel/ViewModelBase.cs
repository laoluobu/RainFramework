using CommunityToolkit.Mvvm.ComponentModel;

namespace RainDesktop.ViewModel
{
    public class ViewModelBase : ObservableObject
    {
    }

    public partial class DialogVMBase : ViewModelBase
    {
        [ObservableProperty]
        private bool? dialogResult;
    }
}
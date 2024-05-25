using CommunityToolkit.Mvvm.Input;
using RainDesktop.ViewModel;

namespace Demo.ViewModel
{
    public partial class LoginDialogVM : DialogVMBase
    {

        [RelayCommand]
        private void Close()
        {
            DialogResult = true;
        }

    }
}

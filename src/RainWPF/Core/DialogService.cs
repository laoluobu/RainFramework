using CommunityToolkit.Diagnostics;
using Microsoft.Win32;
using Stocker.Helper.Dialog;
using System.Windows;

namespace RainWPF.Core
{
    internal class DialogService : IDialogService
    {
        private static Dictionary<Type, Type> mapping = new Dictionary<Type, Type>();

        private void ShowDialog(string dialogName, Action<string>? callback)
        {
            var type = Type.GetType($"StockerClient3.Dailogs.{dialogName}");
            if (type == null)
            {
                ThrowHelper.ThrowMissingMemberException(dialogName);
            }

            OpenDialog(type, callback, null);
        }

        private static void OpenDialog(Type dialogType, Action<string>? callback, object? viewModel)
        {
            var dialog = Activator.CreateInstance(dialogType) as Window;
            if (dialog == null)
            {
                ThrowHelper.ThrowNotSupportedException(nameof(dialogType));
            }

            EventHandler eventHandler = (sender, e) =>
            {
                callback?.Invoke(dialog.DialogResult.ToString() ?? "False");
            };
            if (viewModel != null)
            {
                dialog.DataContext = viewModel;
            }

            dialog.Closed += eventHandler;
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowDialog();
            dialog.Closed -= eventHandler;
        }

        public void ShowDialog<TViewModel>(Action<string>? callback, object? viewModel = null)
        {
            mapping.TryGetValue(typeof(TViewModel), out var dialogType);
            if (dialogType == null)
            {
                ThrowHelper.ThrowArgumentException($"This dialog {nameof(dialogType)} not register");
            }
            OpenDialog(dialogType, callback, viewModel);
        }

        public void Register<TViewMode, TDailog>()
            where TViewMode : class
            where TDailog : class
        {
            mapping.TryAdd(typeof(TViewMode), typeof(TDailog));
        }

        public void ShowDialog<TViewModel>(object? viewModel = null)
        {
            ShowDialog<TViewModel>(null, viewModel);
        }

        public void ShowSaveFileDialog(string tiele, string filter, Action<string, string>? callback)
        {
            var saveFileDialog = new SaveFileDialog()
            {
                Title = tiele,
                Filter = filter
            };
            bool? result = saveFileDialog.ShowDialog();
            callback?.Invoke(result.ToString() ?? "False", saveFileDialog.FileName);
        }
    }
}
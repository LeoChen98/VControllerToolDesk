using CommunityToolkit.Mvvm.Input;
using System.Windows;

#pragma warning disable CS8602

namespace VControllerToolDesk.ViewModel
{
    internal class WindowBasicCommand
    {
        #region Public Properties

        public static RelayCommand<FrameworkElement> Close => new RelayCommand<FrameworkElement>((e) =>
        {
            while (e is not Window)
            {
                e = (FrameworkElement)e.Parent;
            }
            if (e is Window) (e as Window).Close();
        });

        public static RelayCommand<FrameworkElement> MaxOrNormalSize => new RelayCommand<FrameworkElement>((e) =>
        {
            while (e is not Window)
            {
                e = (FrameworkElement)e.Parent;
            }
            if((e as Window).WindowState == WindowState.Maximized)
            {
                (e as Window).WindowState = WindowState.Normal;
            }
            else
            {
                (e as Window).WindowState = WindowState.Maximized;
            }
        });

        public static RelayCommand<FrameworkElement> MiniSize => new RelayCommand<FrameworkElement>((e) =>
        {
            while (e is not Window)
            {
                e = (FrameworkElement)e.Parent;
            }
            (e as Window).WindowState = WindowState.Minimized;
        });

        #endregion Public Properties
    }
}
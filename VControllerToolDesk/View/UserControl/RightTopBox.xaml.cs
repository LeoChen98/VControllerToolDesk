using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8603

namespace VControllerToolDesk.View.UserControl
{
    /// <summary>
    /// RightTopBox.xaml 的交互逻辑
    /// </summary>
    public partial class RightTopBox : System.Windows.Controls.UserControl
    {
        #region Public Fields

        public static readonly DependencyProperty BtnBackgroundProperty = DependencyProperty.Register("BtnBackground", typeof(Brush), typeof(RightTopBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0x01, 0xff, 0xff, 0xff))));
        public static readonly DependencyProperty IsCloseEnabledProperty = DependencyProperty.Register("IsCloseEnabled", typeof(bool), typeof(RightTopBox), new PropertyMetadata(true));
        public static readonly DependencyProperty IsMaxSizeEnabledProperty = DependencyProperty.Register("IsMaxSizeEnabled", typeof(bool), typeof(RightTopBox), new PropertyMetadata(true));
        public static readonly DependencyProperty IsMaxSizeSupportedProperty = DependencyProperty.Register("IsMaxSizeSupported", typeof(bool), typeof(RightTopBox), new PropertyMetadata(true));
        public static readonly DependencyProperty IsMiniSizeEnabledProperty = DependencyProperty.Register("IsMiniSizeEnabled", typeof(bool), typeof(RightTopBox), new PropertyMetadata(true));
        public static readonly DependencyProperty IsMiniSizeSupportedProperty = DependencyProperty.Register("IsMiniSizeSupported", typeof(bool), typeof(RightTopBox), new PropertyMetadata(true));

        #endregion Public Fields

        #region Public Constructors

        public RightTopBox()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public Brush BtnBackground
        {
            get { return (Brush)GetValue(BtnBackgroundProperty); }
            set { SetValue(BtnBackgroundProperty, value); }
        }

        public bool IsCloseEnabled
        {
            get
            {
                return (bool)GetValue(IsCloseEnabledProperty);
            }
            set { SetValue(IsCloseEnabledProperty, value); }
        }

        public bool IsMaxSizeEnabled
        {
            get
            {
                return (bool)GetValue(IsMaxSizeEnabledProperty);
            }
            set { SetValue(IsMaxSizeEnabledProperty, value); }
        }

        public bool IsMaxSizeSupported
        {
            get
            {
                return (bool)GetValue(IsMaxSizeSupportedProperty);
            }
            set { SetValue(IsMaxSizeSupportedProperty, value); }
        }

        public bool IsMiniSizeEnabled
        {
            get
            {
                return (bool)GetValue(IsCloseEnabledProperty);
            }
            set { SetValue(IsCloseEnabledProperty, value); }
        }

        public bool IsMiniSizeSupported
        {
            get
            {
                return (bool)GetValue(IsMiniSizeSupportedProperty);
            }
            set { SetValue(IsMiniSizeSupportedProperty, value); }
        }

        #endregion Public Properties
    }

    public class WindowStateToContraryBtnPathDataConverter : IValueConverter
    {
        #region Private Fields

        private const string MaxSizeBtnPathData = "M 4.5,4 H 11.5 C 11.5,4 12,4 12,4.5 V 11.5 C 12,11.5 12,12 11.5,12 H 4.5 C 4.5,12 4,12 4,11.5 V 4.5 C 4,4.5 4,4 4.5,4z";
        private const string NormalSizeBtnPathData = "M 4.5,6 H 9.5 C 9.5,6 10,6 10,6.5 V 11.5 C 10,11.5 10,12 9.5,12 H 4.5 C 4.5,12 4,12 4,11.5 V 6.5 C 4,6.5 4,6 4.5,6z\r\nM 6,6 V 4.5 C 6,4.5 6,4 6.5,4 H 11.5 C 11.5,4 12,4 12,4.5 V 9.5 C 12,9.5 12,10 11.5,10 H 10";

        #endregion Private Fields

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            if (value is WindowState)
            {
                if ((WindowState)value == WindowState.Normal)
                {
                    return (Geometry)converter.ConvertFrom(MaxSizeBtnPathData);
                }
                else if ((WindowState)value == WindowState.Maximized)
                {
                    return (Geometry)converter.ConvertFrom(NormalSizeBtnPathData);
                }
            }

            if (value is Window)
            {
                if ((value as Window).WindowState == WindowState.Normal)
                {
                    return (Geometry)converter.ConvertFrom(MaxSizeBtnPathData);
                }
                else if ((value as Window).WindowState == WindowState.Maximized)
                {
                    return (Geometry)converter.ConvertFrom(NormalSizeBtnPathData);
                }
            }

            return (Geometry)converter.ConvertFrom(MaxSizeBtnPathData);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }

    public class WindowStateToContraryStringConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WindowState)
            {
                if ((WindowState)value == WindowState.Normal)
                {
                    return "最大化";
                }
                else if ((WindowState)value == WindowState.Maximized)
                {
                    return "恢复窗口大小";
                }
            }

            if (value is Window)
            {
                if ((value as Window).WindowState == WindowState.Normal)
                {
                    return "最大化";
                }
                else if ((value as Window).WindowState == WindowState.Maximized)
                {
                    return "恢复窗口大小";
                }
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrayApp
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MouseOptions m = new MouseOptions();
        public MainWindow()
        {
            InitializeComponent();
            int speed = m.GetMouseSpeed();
            slajdr.Value = speed;
            Left = System.Windows.SystemParameters.WorkArea.Width - Width;
            Top = System.Windows.SystemParameters.WorkArea.Height - Height;

        }

        public const UInt32 SPI_SETMOUSESPEED = 105;


        

        const UInt32 SPIF_SENDWININICHANGE = 0x02;

        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            IntPtr pvParam,
            UInt32 fWinIni);

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int speed = (int)slajdr.Value;
            m.SetMouseSpeed(speed);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int speed = 10;
            m.SetMouseSpeed(speed);
            slajdr.Value = 10;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TrayApp
{
    public class MouseOptions
    {
        [DllImport("user32.dll")]
        public static extern int SystemParametersInfo(int uAction, int uParam, IntPtr lpvParam, int fuWinIni);

        [DllImport("kernel32.dll")]
        public static extern int GetLastError();

        public const int SPI_GETMOUSESPEED = 112;
        public const int SPI_SETMOUSESPEED = 113;


        public int intDefaulSpeed = 10;
        public int intCurrentSpeed;
        private int intNewSpeed;

        public void GetDefaults()
        {
            intCurrentSpeed = GetMouseSpeed();
        }
        public void SetDefaults()
        {
            if (intCurrentSpeed == 20)
            {
                SetMouseSpeed(intDefaulSpeed);
            }
            else if (intCurrentSpeed < 10)
            {
                SetMouseSpeed(intDefaulSpeed);
            }
        }

        public int GetMouseSpeed()
        {
            int intSpeed = 0;
            IntPtr ptr;
            ptr = Marshal.AllocCoTaskMem(4);
            SystemParametersInfo(SPI_GETMOUSESPEED, 0, ptr, 0);
            intSpeed = Marshal.ReadInt32(ptr);
            Marshal.FreeCoTaskMem(ptr);

            return intSpeed;
        }

        public void SetMouseSpeed(int intSpeed)
        {
            IntPtr ptr = new IntPtr(intSpeed);

            int b = SystemParametersInfo(SPI_SETMOUSESPEED, 0, ptr, 0);


        }
    }
}

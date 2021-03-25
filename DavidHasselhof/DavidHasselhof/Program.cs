using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace DavidHasselhof
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]


        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;


        static void Main()
        {
            string photo = @"david.jpg";           
            DisplayPicture(photo);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DavidHasselhof());
        }

       


        public static void DisplayPicture(string file_name)
        {
            uint flags = 0;
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0, file_name, flags))
            {
                Console.WriteLine("Error");
            }
        }



    }
}

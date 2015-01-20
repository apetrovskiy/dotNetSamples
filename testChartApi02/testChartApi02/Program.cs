using System;
using Gtk;

namespace testChartApi02
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Application.Init ();
            MainWindow win = new MainWindow ();
            win.Show ();
            Application.Run ();
        }
    }
}

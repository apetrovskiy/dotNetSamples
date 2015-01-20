using System;
using Gtk;
using GoogleChartSharp;



public partial class MainWindow: Gtk.Window
{
    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
        Build ();
        int[] data = new int[] { 0, 10, 20, 30, 40 };
        LineChart chart = new LineChart(150, 150);
        chart.SetData(data);
        string url = chart.GetUrl();

        this.label2.Text = url;
        this.label2.LineWrap = true;
    }

    protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    {
        Application.Quit ();
        a.RetVal = true;
    }
}

/*
 * Created by SharpDevelop.
 * User: apetrovsky
 * Date: 9/23/2013
 * Time: 4:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NGChart;
//using NGChart.Encoders;
using System.Drawing;

namespace ngchart_test
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            LineChart chart = new LineChart(new ChartSize(200, 125),
                                            new ChartData(new int[]{ 0, 1, 25, 26, 51, 52, 61, 1 }));
            chart.Colors = new ChartColors(Color.DodgerBlue);
            chart.Title = new ChartTitle("Line chart\nsimple one", Color.Olive, 10);
            chart.LineStyles = new LineStyles(new LineStyle(3, 7, 1));
            
            //return chart.ToString();
            Console.WriteLine(chart.ToString());
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 6/13/2013
 * Time: 3:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Globalization;

namespace testLocalization
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    //internal sealed class Program
    public static class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        //[STAThread]
        //private static void Main(string[] args)
        public static void Main(string[] args)
        {
            //System.Globalization.
            try {
                ArrayList list = new ArrayList();
                list.Add("aaa");
                list.Add("bbb");
                list.Add("ccc");
                list[0] = "";
                list[2] = "";
                list.Sort();
                for(int i = 0; i < list.Count; i++) {
                    Console.WriteLine(list[i]);
                }
            }
            catch (Exception e1) {
                Console.WriteLine(e1.Message);
            }
            Console.ReadKey();
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
        }
        
    }
}

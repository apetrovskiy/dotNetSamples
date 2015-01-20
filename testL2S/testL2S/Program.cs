/*
 * Created by SharpDevelop.
<<<<<<< HEAD
 * User: Alexander
 * Date: 12/24/2014
 * Time: 1:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testL2S
{
=======
 * User: alexa_000
 * Date: 12/24/2014
 * Time: 2:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testL2S
{
    using System;
    using System.Data.Linq;
    using testL2S.Mapping;
    
>>>>>>> 9f968410adde0b431d4d999e81c2a2dc1f3f738b
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
<<<<<<< HEAD
            // TODO: Implement Functionality Here
=======
//            var context = new DataContext("Data Source=192.168.129.11;Initial Catalog=Netwrix_Auditor_Windows_Server; Integrated Security=true");
//            var tableChanges = context.GetTable<Changes>();
            
            // var context = new DataContext("Data Source=192.168.129.11; Initial Catalog=Netwrix_Auditor_Event_Log; Integrated Security=false; User=sa; Password=111");
            var context = new MyContext("Data Source=192.168.129.11; Initial Catalog=Netwrix_Auditor_Event_Log; Integrated Security=false; User=sa; Password=111");
            var tableEvents = context.GetTable<Events>();
            
            var en = tableEvents.GetEnumerator();
            while (en.MoveNext()) {
                Console.WriteLine("event id = {0}, source = {1}, level = {2}, user name = {3}", en.Current.Event_ID, en.Current.Event_Source, en.Current.Level, en.Current.User_Name);
            }
>>>>>>> 9f968410adde0b431d4d999e81c2a2dc1f3f738b
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
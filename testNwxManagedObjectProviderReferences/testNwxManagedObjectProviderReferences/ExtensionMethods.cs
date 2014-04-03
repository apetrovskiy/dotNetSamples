/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/3/2014
 * Time: 5:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Xml.Serialization;

namespace testNwxManagedObjectProviderReferences
{
    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static string SerializeToString<T>(this T providerConfiguration)
        {
			var serializer = new XmlSerializer(typeof(T));
            
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, providerConfiguration);
                return writer.ToString();
            }
        }
    }
}

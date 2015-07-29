/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 29/07/2015
 * Time: 10:52 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testRegexpForMailNwx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var dataList = new List<string> {
                @"none",
@"Not trusted changed from ""False"" to ""True""",

@"col1: ""1""
col2: ""ccc""",

@"Size changed from ""30 bytes"" to ""138 bytes""",

@"Group Type: ""Security Domain Local Group""",

@"Removed test01 (REG_SZ): ""test01""
Added test02 (REG_SZ): ""test02-1""",

@"Added AutoBackupLogFiles (REG_DWORD): ""0""",

@"Password changed",

@"Account is : ""enabled""
Description: ""none""
Full Name: ""none""
Name: ""test01""
Password Never Expires: ""No""
User cannot change password: ""No""
User must change password at next logon: ""No""",

@"Members
Added: ""2008R2STD-ES\test01""",

@"Permissions
Added: ""Permissions: NT AUTHORITY\Usuarios autentificados (AccessAllowed: ) Apply onto: this key only; NT AUTHORITY\Usuarios autentificados (AccessAllowed: Query Value, Enumerate Subkeys, Notify, Read Control) Apply onto: this key only; NT AUTHORITY\SYSTEM (AccessAllowed: Query Value, Set Value, Create Subkeys, Enumerate Subkeys, Notify, Create Link, Delete, Read Control, Write DAC, Write Owner) Apply onto: this key only; NT AUTHORITY\SYSTEM (AccessAllowed: ) Apply onto: this key only; BUILTIN\Administradores (AccessAllowed: Query Value, Set Value, Create Subkeys, Enumerate Subkeys, Notify, Create Link, Delete, Read Control, Write DAC, Write Owner) Apply onto: this key only; BUILTIN\Administradores (AccessAllowed: ) Apply onto: this key only"""
            };
            
            var regexKeyValue = new Regex(RegExp.Default.PatternKeyValue, RegexOptions.CultureInvariant | RegexOptions.Compiled);
            var regexRemoved = new Regex(RegExp.Default.PatternRemoved, RegexOptions.CultureInvariant | RegexOptions.Compiled);
            var regexAdded = new Regex(RegExp.Default.PatternAdded, RegexOptions.CultureInvariant | RegexOptions.Compiled);
            
            foreach (var dataElement in dataList) {
                Console.WriteLine("===================================================================");
                
                bool found = false;
                if (regexRemoved.IsMatch(dataElement)) {
                    var matches = regexRemoved.Matches(dataElement);
                    foreach (Match match in matches) {
                        Console.WriteLine("MATCH:");
                        Console.WriteLine(match.Groups["Removed"]);
                        Console.WriteLine(match.Groups["OldValue"]);
                    }
                    found = true;
                }
                if (regexAdded.IsMatch(dataElement)) {
                    var matches = regexAdded.Matches(dataElement);
                    foreach (Match match in matches) {
                        Console.WriteLine("MATCH:");
                        Console.WriteLine(match.Groups["Added"]);
                        Console.WriteLine(match.Groups["NewValue"]);
                    }
                    found = true;
                }
                
                // Added
                
                if (found)
                    continue;
                
                if (regexKeyValue.IsMatch(dataElement)) {
                    var matches = regexKeyValue.Matches(dataElement);
                    foreach (Match match in matches) {
                        Console.WriteLine("MATCH:");
                        Console.WriteLine(match.Groups["Key"]);
                        Console.WriteLine(match.Groups["Value"]);
                    }
                }
//                foreach (var part in parts) {
//                    Console.WriteLine(part);
//                }
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
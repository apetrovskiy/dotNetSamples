/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 02/06/2015
 * Time: 04:40 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testAdsiDomainSearcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.DirectoryServices;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            GetADUsers().ForEach(user => Console.WriteLine(user.UserName + "\t" + user.DisplayName));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        
        public static List<Users> GetADUsers()
        {
            try
            {
                var lstADUsers = new List<Users>();
                string DomainPath = "LDAP://spanew";
                // var DomainPath = "LDAP://dc=spalab,dc=at,dc=local";
                var searchRoot = new DirectoryEntry(DomainPath); 
                var search = new DirectorySearcher(searchRoot);
                // search.Filter = "(&(objectClass=user)(objectCategory=person))";
                search.Filter = "(|(objectClass=user)(objectClass=group))";
                search.PropertiesToLoad.Add("samaccountname");
                // search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("usergroup");
                search.PropertiesToLoad.Add("displayname");//first name
                search.SearchScope = SearchScope.Subtree;
                SearchResult result;
                SearchResultCollection resultCol = search.FindAll();
                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        string UserNameEmailString = string.Empty;
                        result = resultCol[counter];
//                        if (result.Properties.Contains("samaccountname") && 
//                                 // result.Properties.Contains("mail") && 
//                            result.Properties.Contains("displayname"))
//                        {
//                            var objSurveyUsers = new Users();
//                            // objSurveyUsers.Email = (String)result.Properties["mail"][0] + 
//                            //   "^" + (String)result.Properties["displayname"][0];
//                            objSurveyUsers.UserName = (String)result.Properties["samaccountname"][0];
//                            objSurveyUsers.DisplayName = (String)result.Properties["displayname"][0];
//                            lstADUsers.Add(objSurveyUsers);
//                        }
                        lstADUsers.Add(new Users { UserName = (String)result.Properties["samaccountname"][0] });
                    }
                }
                return lstADUsers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Users>();
            }
        }
    }
}
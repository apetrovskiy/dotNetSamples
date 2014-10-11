/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/12/2014
 * Time: 1:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TfsAutomation.Core
{
	using System;
	public class TfsData
	{
		// VERB https://{account}.VisualStudio.com/DefaultCollection/_apis[/{area}]/{resource}?api-version=1.0-preview
		// GET https://{account}.visualstudio.com/defaultcollection/_apis/git[/{project}]/repositories?api-version={version}
		// GET https://app.vssps.visualstudio.com/_apis/accounts/{account}?api-version={version}
		// GET https://fabrikam.visualstudio.com/DefaultCollection/_apis/projectCollections?api-version=1.0-preview.2
		// GET https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1/teams?api-version=1.0-preview.1
		// GET https://{account}.visualstudio.com/defaultcollection/_apis/build/requests?api-version={version}[&projectname={string}&requestedfor={string}&definitionid={int}&controllerid={int}&maxcompletedage={int}&status={string}&$top={int}&$skip={int}]
		// GET https://app.vssps.visualstudio.com/_apis/profile/profiles/me
		// GET https://fabrikam.visualstudio.com/DefaultCollection/_apis/chat/rooms/305/users?api-version=1.0-preview.1
		// POST https://fabrikam.visualstudio.com/defaultcollection/_apis/hooks/subscriptions?api-version=1.0-preview.1
		// GET https://fabrikam.visualstudio.com/DefaultCollection/_apis/test/fabrikam-fiber-tfvc/plans/1/suites?api-version=1.0-preview.1
		// GET http://{account}.visualstudio.com/defaultcollection/_apis/test/{project}/runs/{run}/results?api-version={version}[&includeiterationdetails={bool}]
		// GET https://fabrikam.visualstudio.com/DefaultCollection/_apis/test/fabrikam-fiber-tfvc/runs/4/results?api-version=1.0-preview.1
		// GET http://{account}.visualstudio.com/defaultcollection/_apis/test/{project}/plans/{plan}/suites/{suite}?api-version={version}
		// GET http://{account}.visualstudio.com/defaultcollection/_apis/test/{project}/plans/{plan}/suites/{suite}/testcases/{case}?api-version={version}
		// GET https://{account}.visualstudio.com/defaultcollection/_apis/tfvc/shelvesets?api-version={version}[&owner={string}&maxcontentlength={int}&$top={int}&$skip={int}]
		// GET https://fabrikam.visualstudio.com/DefaultCollection/_apis/tfvc/shelvesets/My%20first%20shelveset;d6245f20-2af8-44f4-9451-8107cb2767db?api-version=1.0-preview.1
		// GET https://{account}.visualstudio.com/defaultcollection/{project}/_apis/wit/workitemtypecategories?api-version={version}
		// GET https://fabrikam.visualstudio.com/DefaultCollection/Fabrikam-Fiber-Git/_apis/wit/workItemTypeCategories/Microsoft.RequirementCategory?api-version=1.0-preview.2
		// GET https://{account}.visualstudio.com/defaultcollection/_apis/wit/fields/{fieldname}?api-version={version}
		// public static string VisualStudioAccountName { get; set; } // ?

		// https://{account}.visualstudio.com/
		public static string BaseUrl { get; set; }

		public static string CurrentProjectCollectionName { get; set; }
		public static string CurrentProjectName { get; set; }

		public static string ApiVersion { get; set; }

		internal static string BaseUrlAccounts = BaseUrl + "/_apis/accounts/";
		internal static string BaseUtlCollectionApis = BaseUrl + "/" + CurrentProjectCollectionName + "/_apis/";
		internal static string BaseUtlProjectApis = BaseUrl + "/" + CurrentProjectCollectionName + "/" + CurrentProjectName + "/_apis/";
	}
}


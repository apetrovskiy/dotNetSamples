/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/10/2014
 * Time: 5:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
	using System;
	using System.Linq;
	using Nancy;
	using Nancy.ModelBinding;
	using testInterfaces;
	
	/// <summary>
	/// Description of TestBucketModule.
	/// </summary>
	public class TestBucketModule : NancyModule
	{
		public TestBucketModule() : base("/v1")
		{
			Get["/TestBuckets/freeBucket"] = parameter => {
				var tempBucket = this.Bind<TestActivity>();
				var testBucket = TestBucketsStorage.TestBuckets.First(tb => tb.Status == TestActivityStatuses.New && tb.HostId.ToUpper() == tempBucket.HostId.ToUpper());
				return Response.AsJson<ITestActivity>(testBucket, HttpStatusCode.OK);
			};
			
			Get["/TestBuckets/{id}"] = parameters => {
				var testBucket = TestBucketsStorage.TestBuckets.First(tb => tb.Id == parameters.id);
				testBucket.Name += " presented ";
				return Response.AsJson<ITestActivity>(testBucket, HttpStatusCode.OK);
			};
			
			Put["/TestBuckets/{id}"] = parameters => {
				var testBucketFromRequest = this.Bind<TestActivity>();
//				var testBucket = TestBucketsStorage.TestBuckets.First(tb => tb.Id == parameters.id);
				// testBucket.Name += " put 01";
				// TestBucketsStorage.TestBuckets.First(tb => tb.Id == parameters.id).Name += " put 01";
				var testBucket = TestBucketsStorage.TestBuckets.First(tb => tb.Id == parameters.id);
				// testBucketInStorage = testBucket;
				if (null != testBucket && null != testBucketFromRequest)
					testBucket = testBucketFromRequest;
				else
					return Response.AsJson<ITestActivity>(null, HttpStatusCode.Conflict);
//				var tempBucket = this.Bind<TestBucket>();
//				testBucket.Status = tempBucket.Status;
				return Response.AsJson<ITestActivity>(testBucket, HttpStatusCode.OK);
			};
		}
	}
}

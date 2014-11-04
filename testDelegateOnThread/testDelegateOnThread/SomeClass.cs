/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 8/5/2014
 * Time: 11:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;

namespace testDelegateOnThread
{
// Create a delegate for our callback function.
public delegate void SomeThreadTaskCompleted(string taskId, bool isError);


	public class SomeClass
	{
	
	    // private void DoBackgroundWork()
	    public void DoBackgroundWork()
	    {
	        // Create a ThreadTask object.
	
	        SomeThreadTask threadTask = new SomeThreadTask();
	
	        // Create a task id.  Quick and dirty here to keep it simple.  
	        // Read about threading and task identifiers to learn 
	        // various ways people commonly do this for production code.
	
	        threadTask.TaskId = "MyTask" + DateTime.Now.Ticks.ToString();
	
	        // Set the thread up with a callback function pointer.
	
	        threadTask.CompletedCallback = 
	            new SomeThreadTaskCompleted(SomeThreadTaskCompletedCallback);
	
	
	        // Create a thread.  We only need to specify the entry point function.
	        // Framework creates the actual delegate for thread with this entry point.
	
	        Thread thread = new Thread(threadTask.ExecuteThreadTask);
	
	        // Do something with our thread and threadTask object instances just created
	        // so we could cancel the thread etc.  Can be as simple as stick 'em in a bag
	        // or may need a complex manager, just depends.
	
	        // GO!
	        thread.Start();
	
	        // Go do something else.  When task finishes we will get a callback.
	
	    }
	
	    /// <summary>
	    /// Method that receives callbacks from threads upon completion.
	    /// </summary>
	    /// <param name="taskId"></param>
	    /// <param name="isError"></param>
	    public void SomeThreadTaskCompletedCallback(string taskId, bool isError)
	    {
	        // Do post background work here.
	        // Cleanup the thread and task object references, etc.
	        Console.WriteLine("callback!");
	    }
	}
}

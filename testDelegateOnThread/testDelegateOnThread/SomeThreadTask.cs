/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 8/5/2014
 * Time: 11:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testDelegateOnThread
{
	/// <summary>
	/// ThreadTask defines the work a thread needs to do and also provides any data 
	/// required along with callback pointers etc.
	/// Populate a new ThreadTask instance with any data the thread needs 
	/// then start the thread to execute the task.
	/// </summary>
	internal class SomeThreadTask
	{
	
	    private string _taskId;
	    private SomeThreadTaskCompleted _completedCallback;
	
	    /// <summary>
	    /// Get. Set simple identifier that allows main thread to identify this task.
	    /// </summary>
	    internal string TaskId
	    {
	        get { return _taskId; }
	        set { _taskId = value; }
	    }
	
	    /// <summary>
	    /// Get, Set instance of a delegate used to notify the main thread when done.
	    /// </summary>
	    internal SomeThreadTaskCompleted CompletedCallback
	    {
	        get { return _completedCallback; }
	        set { _completedCallback = value; }
	    }
	
	    /// <summary>
	    /// Thread entry point function.
	    /// </summary>
	    internal void ExecuteThreadTask()
	    {
	        // Often a good idea to tell the main thread if there was an error
	        bool isError = false;
	
	        // Thread begins execution here.
	
	        // You would start some kind of long task here 
	        // such as image processing, file parsing, complex query, etc.
	
	        // Thread execution eventually returns to this function when complete.
	
	        // Execute callback to tell main thread this task is done.
	        _completedCallback.Invoke(_taskId, isError);
	
	
	    }
	
	}
}

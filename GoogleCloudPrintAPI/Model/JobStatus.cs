/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace GoogleCloudPrintAPI.Model
{

	/// <summary>
	/// Status of the job, which can be one of the following:<br/><br/>
	/// <b>QUEUED</b>: Job just added and has not yet been downloaded.<br/>
	/// <b>IN_PROGRESS</b>: Job downloaded and has been added to the client-side
	/// native printer queue.<br/>
	/// <b>DONE</b>: Job printed successfully.<br/>
	/// <b>ERROR</b>: Job cannot be printed due to an error.
	/// 
	/// @author jittagorn pitakmetagoon
	/// </summary>
	public enum JobStatus
	{

		/// <summary>
		/// <b>QUEUED</b>: Job just added and has not yet been downloaded.
		/// </summary>
		QUEUED,
		/// <summary>
		/// <b>IN_PROGRESS</b>: Job downloaded and has been added to the client-side
		/// native printer queue.
		/// </summary>
		IN_PROGRESS,
		/// <summary>
		/// <b>DONE</b>: Job printed successfully.
		/// </summary>
		DONE,
		/// <summary>
		/// <b>ERROR</b>: Job cannot be printed due to an error.
		/// </summary>
		ERROR
	}

}
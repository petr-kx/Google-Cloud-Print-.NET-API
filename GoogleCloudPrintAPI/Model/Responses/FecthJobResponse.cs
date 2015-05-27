using System.Collections.Generic;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace GoogleCloudPrintAPI.Model.Responses
{


	/// 
	/// <summary>
	/// @author jittagorn pitakmetagoon
	/// </summary>
	public class FecthJobResponse : CloudPrintResponse
	{

		private IList<Job> jobs;
		private string errorCode;


		public virtual IList<Job> Jobs
		{
			get
			{
				return jobs;
			}
			set
			{
				this.jobs = value;
			}
		}


		public virtual string ErrorCode
		{
			get
			{
				return errorCode;
			}
			set
			{
				this.errorCode = value;
			}
		}

	}

}
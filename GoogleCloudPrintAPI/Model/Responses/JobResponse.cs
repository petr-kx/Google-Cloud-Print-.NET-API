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
	public class JobResponse : CloudPrintResponse
	{

		private IList<Job> jobs;
		private int jobsCount;
		private string jobsTotal;

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


		public virtual int JobsCount
		{
			get
			{
				return jobsCount;
			}
			set
			{
				this.jobsCount = value;
			}
		}


		public virtual string JobsTotal
		{
			get
			{
				return jobsTotal;
			}
			set
			{
				this.jobsTotal = value;
			}
		}

	}

}
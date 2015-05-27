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
	public class SubmitJobResponse : CloudPrintResponse
	{

		private Job job;

		public virtual Job Job
		{
			get
			{
				return job;
			}
			set
			{
				this.job = value;
			}
		}

	}

}
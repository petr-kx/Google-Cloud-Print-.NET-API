/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace GoogleCloudPrintAPI.Model
{

	/// 
	/// <summary>
	/// @author jittagorn pitakmetagoon
	/// </summary>
	public class Ticket
	{

		private string version = "1.0";
		private PrintTicket print;

		public virtual string Version
		{
			get
			{
				return version;
			}
			set
			{
				this.version = value;
			}
		}


		public virtual PrintTicket Print
		{
			get
			{
				return print;
			}
			set
			{
				this.print = value;
			}
		}

	}

}
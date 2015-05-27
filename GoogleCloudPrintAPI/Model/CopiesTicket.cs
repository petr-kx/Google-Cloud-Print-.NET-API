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
	public class CopiesTicket
	{

		private int copies;

		public virtual int Copies
		{
			get
			{
				return copies;
			}
			set
			{
				this.copies = value;
			}
		}

	}

}
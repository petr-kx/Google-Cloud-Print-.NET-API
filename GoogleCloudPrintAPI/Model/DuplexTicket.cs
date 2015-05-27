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
	public class DuplexTicket
	{

		private int type;

		public virtual int Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}

	}

}
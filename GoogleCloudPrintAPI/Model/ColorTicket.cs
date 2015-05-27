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
	public class ColorTicket
	{

		private string vendor_id;
		private int type;

		public virtual string Vendor_id
		{
			get
			{
				return vendor_id;
			}
			set
			{
				this.vendor_id = value;
			}
		}


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
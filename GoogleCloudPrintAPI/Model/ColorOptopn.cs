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
	public class ColorOptopn
	{

		private bool is_default;
		private string type;
		private string vendor_id;

		public virtual bool Is_default
		{
			get
			{
				return is_default;
			}
			set
			{
				this.is_default = value;
			}
		}


		public virtual string Type
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

	}

}
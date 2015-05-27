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
	public class SelectCapabilityOption
	{

		private string display_name;
		private string value;
		private bool is_defaul;

		public virtual string Display_name
		{
			get
			{
				return display_name;
			}
			set
			{
				this.display_name = value;
			}
		}


		public virtual string Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}


		public virtual bool Is_defaul
		{
			get
			{
				return is_defaul;
			}
			set
			{
				this.is_defaul = value;
			}
		}

	}

}
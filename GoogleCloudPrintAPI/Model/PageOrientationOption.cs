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
	public class PageOrientationOption
	{

		private bool is_default;
		private string type;

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

	}

}
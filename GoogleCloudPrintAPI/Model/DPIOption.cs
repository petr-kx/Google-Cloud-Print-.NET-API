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
	public class DPIOption
	{

		private int vertical_dpi;
		private bool is_default;
		private int horizontal_dpi;

		public virtual int Vertical_dpi
		{
			get
			{
				return vertical_dpi;
			}
			set
			{
				this.vertical_dpi = value;
			}
		}


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


		public virtual int Horizontal_dpi
		{
			get
			{
				return horizontal_dpi;
			}
			set
			{
				this.horizontal_dpi = value;
			}
		}

	}

}
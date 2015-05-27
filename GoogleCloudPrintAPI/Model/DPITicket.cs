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
	public class DPITicket
	{

		private int horizontal_dpi;
		private int vertical_dpi;

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

	}

}
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
	public class MediaSizeTicket
	{

		private int width_microns;
		private int height_microns;
		private bool is_continuous_feed;

		public virtual int Width_microns
		{
			get
			{
				return width_microns;
			}
			set
			{
				this.width_microns = value;
			}
		}


		public virtual int Height_microns
		{
			get
			{
				return height_microns;
			}
			set
			{
				this.height_microns = value;
			}
		}


		public virtual bool Is_continuous_feed
		{
			get
			{
				return is_continuous_feed;
			}
			set
			{
				this.is_continuous_feed = value;
			}
		}

	}

}
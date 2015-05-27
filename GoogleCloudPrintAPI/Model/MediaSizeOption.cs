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
	public class MediaSizeOption
	{

		private int height_microns;
		private int width_microns;
		private string name;
		private bool is_continuous_feed;
		private bool is_default;

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


		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
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

	}

}
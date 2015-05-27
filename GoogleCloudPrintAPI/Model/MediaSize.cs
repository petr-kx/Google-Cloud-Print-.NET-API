using System.Collections.Generic;

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
	public class MediaSize
	{

		private IList<MediaSizeOption> option;

		public virtual IList<MediaSizeOption> Option
		{
			get
			{
				return option;
			}
			set
			{
				this.option = value;
			}
		}

	}

}
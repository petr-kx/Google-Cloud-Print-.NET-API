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
	public class SupportedContentType
	{

		private string content_type;

		public virtual string Content_type
		{
			get
			{
				return content_type;
			}
			set
			{
				this.content_type = value;
			}
		}

	}

}
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
	public class Collate
	{

		private bool deflt;

		public virtual bool Default
		{
			get
			{
				return deflt;
			}
			set
			{
				this.deflt = value;
			}
		}

	}

}
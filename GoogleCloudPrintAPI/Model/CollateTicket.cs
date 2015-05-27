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
	public class CollateTicket
	{

		private bool collate;

		public virtual bool Collate
		{
			get
			{
				return collate;
			}
			set
			{
				this.collate = value;
			}
		}

	}

}
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
	public class Copies
	{

		private int max;
		private int deflt;

		public virtual int Max
		{
			get
			{
				return max;
			}
			set
			{
				this.max = value;
			}
		}


		public virtual int Default
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
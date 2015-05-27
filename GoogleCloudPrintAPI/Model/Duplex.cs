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
	public class Duplex
	{

		private IList<DuplexOption> option;

		public virtual IList<DuplexOption> Option
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
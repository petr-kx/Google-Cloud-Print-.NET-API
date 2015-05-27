using System.Collections.Generic;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace GoogleCloudPrintAPI.Model.Responses
{


	/// 
	/// <summary>
	/// @author jittagorn pitakmetagoon
	/// </summary>
	public class SearchPrinterResponse : CloudPrintResponse
	{

		private IList<Printer> printers;

		public virtual IList<Printer> Printers
		{
			get
			{
				return printers;
			}
			set
			{
				this.printers = value;
			}
		}

	}

}
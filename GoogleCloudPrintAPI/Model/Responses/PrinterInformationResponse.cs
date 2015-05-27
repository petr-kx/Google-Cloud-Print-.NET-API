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
	public class PrinterInformationResponse : CloudPrintResponse
	{
	    public virtual List<Printer> Printers { get; set; }
	}

}
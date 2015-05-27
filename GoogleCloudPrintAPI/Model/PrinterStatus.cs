/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace GoogleCloudPrintAPI.Model
{

	/// <summary>
	/// connectionStatus: printer's connection status, which can be one of the
	/// following:<br/><br/>
	/// <b>ONLINE</b>: The printer has an active XMPP connection to Google Cloud
	/// Print.<br/>
	/// <b>UNKNOWN</b>: The printer's connection status cannot be determined.<br/>
	/// <b>OFFLINE</b>: The printer is offline.<br/>
	/// <b>DORMANT</b>: The printer has been offline for quite a while.<br/>
	/// <b>ALL</b> : Match all printers.
	/// 
	/// @author jittagorn pitakmetagoon
	/// </summary>
	public enum PrinterStatus
	{

		/// <summary>
		/// <b>ONLINE</b>: The printer has an active XMPP connection to Google Cloud
		/// Print.
		/// </summary>
		ONLINE,
		/// <summary>
		/// <b>UNKNOWN</b>: The printer's connection status cannot be determined.
		/// </summary>
		UNKNOWN,
		/// <summary>
		/// <b>OFFLINE</b>: The printer is offline.
		/// </summary>
		OFFLINE,
		/// <summary>
		/// <b>DORMANT</b>: The printer has been offline for quite a while.
		/// </summary>
		DORMANT,
		/// <summary>
		/// <b>ALL</b> : Match all printers.
		/// </summary>
		ALL
	}
}
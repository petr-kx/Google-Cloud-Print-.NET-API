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
	public class Capabilities
	{

		private PrinterCapability printer;
		private string version;

		public virtual PrinterCapability Printer
		{
			get
			{
				return printer;
			}
			set
			{
				this.printer = value;
			}
		}


		public virtual string Version
		{
			get
			{
				return version;
			}
			set
			{
				this.version = value;
			}
		}

	}

}
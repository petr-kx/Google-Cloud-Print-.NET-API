using System;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace GoogleCloudPrintAPI.Exceptions
{

	/// 
	/// <summary>
	/// @author jittagorn pitakmetagoon
	/// </summary>
	public class CloudPrintException : Exception
	{

		public CloudPrintException() : base()
		{
		}

		public CloudPrintException(string message) : base(message)
		{
		}

		public CloudPrintException(string message, Exception cause) : base(message, cause)
		{
		}

	}

}
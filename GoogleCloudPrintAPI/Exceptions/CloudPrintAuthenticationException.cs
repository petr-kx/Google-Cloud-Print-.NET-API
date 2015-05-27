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
	public class CloudPrintAuthenticationException : CloudPrintException
	{

		public CloudPrintAuthenticationException() : base()
		{
		}

		public CloudPrintAuthenticationException(string message) : base(message)
		{
		}

		public CloudPrintAuthenticationException(string message, Exception cause) : base(message, cause)
		{
		}

	}

}
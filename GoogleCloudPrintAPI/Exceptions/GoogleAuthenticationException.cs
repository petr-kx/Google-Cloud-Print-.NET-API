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
	public class GoogleAuthenticationException : Exception
	{

		public GoogleAuthenticationException() : base()
		{
		}

		public GoogleAuthenticationException(string message) : base(message)
		{
		}

		public GoogleAuthenticationException(string message, Exception cause) : base(message, cause)
		{
		}

	}

}
using System;
using System.IO;
using System.Text;
using GoogleCloudPrintAPI.Exceptions;
using GoogleCloudPrintAPI.Helpers;

namespace GoogleCloudPrintAPI
{

	/*
	 * To change this template, choose Tools | Templates
	 * and open the template in the editor.
	 */


	/// 
	/// <summary>
	/// @author jittagorn pitakmetagoon
	/// </summary>
	public class GoogleAuthentication
	{

		public const string LOGIN_URL = "https://www.google.com/accounts/ClientLogin";
		private const string ACCOUNT_TYPE = "HOSTED_OR_GOOGLE";
		//request by user
		private string serviceName;
		private string source;
		//response from google
		private string auth;
		private string sid;
		private string lsid;

		private GoogleAuthentication()
		{
		}

		public GoogleAuthentication(string serviceName)
		{
			this.serviceName = serviceName;
		}

		/// <summary>
		/// For login Google Service<br/>
		/// <a href='https://developers.google.com/accounts/docs/AuthForInstalledApps'>https://developers.google.com/accounts/docs/AuthForInstalledApps</a>
		/// </summary>
		/// <param name="email"> Google Account or Google Email </param>
		/// <param name="password"> Email Password </param>
		/// <param name="source"> Short string identifying your application, for logging
		/// purposes. This string take from :
		/// "companyName-applicationName-VersionID". </param>
		/// <exception cref="GoogleAuthenticationException"> </exception>
		public virtual void login(string email, string password, string source)
		{
			try
			{
			    string uri = (new StringBuilder()).Append(LOGIN_URL).Append("?accountType=").Append(ACCOUNT_TYPE)
			                                   .Append("&Email=").Append(email).Append("&Passwd=").Append(password)
			                                   .Append("&service=")
			                                   .Append(serviceName)
			                                   .Append("&source=")
			                                   .Append(source)
			                                   .ToString();

			    string response = HttpHelper.HttpPost(uri, "");

				string[] split = response.Split('\n');
				foreach (string @string in split)
				{
					string[] keyValueSplit = @string.Split('=');
					if (keyValueSplit.Length == 2)
					{
						string key = keyValueSplit[0];
						string value = keyValueSplit[1];

						if (key.Equals("Auth", StringComparison.CurrentCultureIgnoreCase))
						{
							auth = value;
						}
						else if (key.Equals("SID", StringComparison.CurrentCultureIgnoreCase))
						{
							sid = value;
						}
						else if (key.Equals("LSID", StringComparison.CurrentCultureIgnoreCase))
						{
							lsid = value;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new GoogleAuthenticationException(ex.Message);
			}
		}

		public virtual string Source
		{
			get
			{
				return source;
			}
		}

		public virtual string ServiceName
		{
			get
			{
				return serviceName;
			}
		}

		public virtual string Auth
		{
			get
			{
				return auth;
			}
		}

		public virtual string Sid
		{
			get
			{
				return sid;
			}
		}

		public virtual string Lsid
		{
			get
			{
				return lsid;
			}
		}
	}

}
using System;
using System.Collections.Generic;
using System.Linq;

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
	public class Printer
	{
	    private PrinterStatus connectionStatus;
		private string supportedContentTypes;

	    public virtual string Id { get; set; }
	    public virtual string OwnerId { get; set; }


	    public virtual string Name { get; set; }


	    public virtual string Proxy { get; set; }


	    public virtual string Description { get; set; }


	    public virtual string Status { get; set; }


	    public virtual PrinterStatus getConnectionStatus()
		{
			return connectionStatus;
		}

		public virtual void setConnectionStatus(PrinterStatus connectionStatus)
		{
			this.connectionStatus = connectionStatus;
		}

		public virtual void setConnectionStatus(string connectionStatus)
		{
            if (!Enum.TryParse(connectionStatus, true, out this.connectionStatus))
			{
				this.connectionStatus = PrinterStatus.UNKNOWN;
			}
		}

		public virtual string SupportedContentTypes
		{
			get
			{
				return supportedContentTypes;
			}
			set
			{
				this.supportedContentTypes = value;
			}
		}


	    public virtual string CreateTime { get; set; }


	    public virtual string UpdateTime { get; set; }


	    public virtual string AccessTime { get; set; }


	    public virtual string Type { get; set; }


	    public virtual string GcpVersion { get; set; }


	    public virtual string CapsHash { get; set; }


	    public virtual bool IsTosAccepted { get; set; }


	    public virtual string DefaultDisplayName { get; set; }


	    public virtual string DisplayName { get; set; }


	    public virtual HashSet<string> Tags { get; set; }

	    public virtual object Capabilities { get; set; }


	    public virtual object Defaults { get; set; }


	    public virtual List<Access> Access { get; set; }


	    public virtual string CapsFormat { get; set; }


	    public override int GetHashCode()
		{
			int hash = 3;
			hash = 29 * hash + (this.Id != null ? this.Id.GetHashCode() : 0);
			return hash;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this.GetType() != obj.GetType())
			{
				return false;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Printer other = (Printer) obj;
			Printer other = (Printer) obj;
			if ((this.Id == null) ? (other.Id != null) :!this.Id.Equals(other.Id))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
            return "{" + "\n\t id = " + Id + "," + "\n\t ownerId = " + OwnerId + "," + "\n\t name = " + Name + "," + "\n\t proxy = " + Proxy + "," + "\n\t description = " + Description + "," + "\n\t status = " + Status + "," + "\n\t connectionStatus = " + connectionStatus + "," + "\n\t supportedContentTypes = " + supportedContentTypes + "," + "\n\t createTime = " + CreateTime + "," + "\n\t updateTime = " + UpdateTime + "," + "\n\t accessTime = " + AccessTime + "," + "\n\t type = " + Type + "," + "\n\t gcpVersion = " + GcpVersion + "," + "\n\t capsHash = " + CapsHash + "," + "\n\t isTosAccepted = " + IsTosAccepted + "," + "\n\t defaultDisplayName = " + DefaultDisplayName + "," + "\n\t displayName = " + DisplayName + "," + "\n\t tags = " + Tags + "," + "\n\t capabilities = " + Capabilities + "," + "\n\t defaults = " + Defaults + "," + "\n\t access = " + Access + "\n}";
		}

	}

}
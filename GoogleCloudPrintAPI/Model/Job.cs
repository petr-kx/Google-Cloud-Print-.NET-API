using System;
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
	public class Job
	{

		private string createTime;
		private HashSet<string> tags;
		private string printerName;
		private string updateTime;
		private JobStatus status;
		private string ownerId;
		private string ticketUrl;
		private string printerid;
		private string printerType;
		private string contentType;
		private string fileUrl;
		private string id;
		private string message;
		private string title;
		private string errorCode;
		private int numberOfPages;

		public virtual string CreateTime
		{
			get
			{
				return createTime;
			}
			set
			{
				this.createTime = value;
			}
		}


		public virtual HashSet<string> Tags
		{
			get
			{
				return tags;
			}
			set
			{
				this.tags = value;
			}
		}


		public virtual string PrinterName
		{
			get
			{
				return printerName;
			}
			set
			{
				this.printerName = value;
			}
		}


		public virtual string UpdateTime
		{
			get
			{
				return updateTime;
			}
			set
			{
				this.updateTime = value;
			}
		}


		public virtual JobStatus getStatus()
		{
			return status;
		}

		public virtual void setStatus(JobStatus status)
		{
			this.status = status;
		}

		public virtual void setStatus(string jobStatus)
		{
            if (!Enum.TryParse(jobStatus, true, out this.status))
            {
                status = JobStatus.ERROR;
            }
		}

		public virtual string OwnerId
		{
			get
			{
				return ownerId;
			}
			set
			{
				this.ownerId = value;
			}
		}


		public virtual string TicketUrl
		{
			get
			{
				return ticketUrl;
			}
			set
			{
				this.ticketUrl = value;
			}
		}


		public virtual string Printerid
		{
			get
			{
				return printerid;
			}
			set
			{
				this.printerid = value;
			}
		}


		public virtual string PrinterType
		{
			get
			{
				return printerType;
			}
			set
			{
				this.printerType = value;
			}
		}


		public virtual string ContentType
		{
			get
			{
				return contentType;
			}
			set
			{
				this.contentType = value;
			}
		}


		public virtual string FileUrl
		{
			get
			{
				return fileUrl;
			}
			set
			{
				this.fileUrl = value;
			}
		}


		public virtual string Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}


		public virtual string Message
		{
			get
			{
				return message;
			}
			set
			{
				this.message = value;
			}
		}


		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}


		public virtual string ErrorCode
		{
			get
			{
				return errorCode;
			}
			set
			{
				this.errorCode = value;
			}
		}


		public virtual int NumberOfPages
		{
			get
			{
				return numberOfPages;
			}
			set
			{
				this.numberOfPages = value;
			}
		}


		public override int GetHashCode()
		{
			int hash = 7;
			hash = 71 * hash + (this.id != null ? this.id.GetHashCode() : 0);
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
//ORIGINAL LINE: final Job other = (Job) obj;
			Job other = (Job) obj;
			if ((this.id == null) ? (other.id != null) :!this.id.Equals(other.id))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "{" + "\n\t createTime = " + createTime + "," + "\n\t tags = " + tags + "," + "\n\t printerName = " + printerName + "," + "\n\t updateTime = " + updateTime + "," + "\n\t status = " + status + "," + "\n\t ownerId = " + ownerId + "," + "\n\t ticketUrl = " + ticketUrl + "," + "\n\t printerid = " + printerid + "," + "\n\t printerType = " + printerType + "," + "\n\t contentType = " + contentType + "," + "\n\t fileUrl = " + fileUrl + "," + "\n\t id = " + id + "," + "\n\t message = " + message + "," + "\n\t title = " + title + "," + "\n\t errorCode = " + errorCode + "," + "\n\t numberOfPages = " + numberOfPages + "," + "\n\t tags = " + tags + "\n}";
		}

	}

}
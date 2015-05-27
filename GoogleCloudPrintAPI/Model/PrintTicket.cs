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
	public class PrintTicket
	{

		private IList<VendorTicketItem> vendor_ticket_item;
		private ColorTicket color;
		private DuplexTicket duplex;
		private PageOrientationTicket page_orientation;
		private CopiesTicket copies;
		private DPITicket dpi;
		private MediaSizeTicket media_size;
		private CollateTicket collate;

		public virtual IList<VendorTicketItem> Vendor_ticket_item
		{
			get
			{
				return vendor_ticket_item;
			}
			set
			{
				this.vendor_ticket_item = value;
			}
		}


		public virtual ColorTicket Color
		{
			get
			{
				return color;
			}
			set
			{
				this.color = value;
			}
		}


		public virtual DuplexTicket Duplex
		{
			get
			{
				return duplex;
			}
			set
			{
				this.duplex = value;
			}
		}


		public virtual PageOrientationTicket Page_orientation
		{
			get
			{
				return page_orientation;
			}
			set
			{
				this.page_orientation = value;
			}
		}


		public virtual CopiesTicket Copies
		{
			get
			{
				return copies;
			}
			set
			{
				this.copies = value;
			}
		}


		public virtual DPITicket Dpi
		{
			get
			{
				return dpi;
			}
			set
			{
				this.dpi = value;
			}
		}


		public virtual MediaSizeTicket Media_size
		{
			get
			{
				return media_size;
			}
			set
			{
				this.media_size = value;
			}
		}


		public virtual CollateTicket Collate
		{
			get
			{
				return collate;
			}
			set
			{
				this.collate = value;
			}
		}

	}

}
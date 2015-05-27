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
	public class PrinterCapability
	{

		private Copies copies;
		private IList<SupportedContentType> supported_content_type;
		private Color color;
		private Collate collate;
		private MediaSize media_size;
		private PageOrientation page_orientation;
		private IList<VendorCapability> vendor_capability;
		private DPI dpi;
		private Duplex duplex;

		public virtual Copies Copies
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


		public virtual IList<SupportedContentType> Supported_content_type
		{
			get
			{
				return supported_content_type;
			}
			set
			{
				this.supported_content_type = value;
			}
		}


		public virtual Color Color
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


		public virtual Collate Collate
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


		public virtual MediaSize Media_size
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


		public virtual PageOrientation Page_orientation
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


		public virtual IList<VendorCapability> Vendor_capability
		{
			get
			{
				return vendor_capability;
			}
			set
			{
				this.vendor_capability = value;
			}
		}


		public virtual DPI Dpi
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


		public virtual Duplex Duplex
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

	}

}
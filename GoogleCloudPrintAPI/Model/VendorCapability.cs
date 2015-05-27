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
	public class VendorCapability
	{

		private string id;
		private string display_name;
		private string type;
		private SelectCapability select_cap;
		private TypedValueCapability typed_value_cap;

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


		public virtual string Display_name
		{
			get
			{
				return display_name;
			}
			set
			{
				this.display_name = value;
			}
		}


		public virtual string Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}


		public virtual SelectCapability Select_cap
		{
			get
			{
				return select_cap;
			}
			set
			{
				this.select_cap = value;
			}
		}


		public virtual TypedValueCapability Typed_value_cap
		{
			get
			{
				return typed_value_cap;
			}
			set
			{
				this.typed_value_cap = value;
			}
		}

	}

}
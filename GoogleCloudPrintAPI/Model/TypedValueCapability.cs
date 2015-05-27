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
	public class TypedValueCapability
	{

		private string value_type;
		private string deflt;

		public virtual string Value_type
		{
			get
			{
				return value_type;
			}
			set
			{
				this.value_type = value;
			}
		}


		public virtual string Default
		{
			get
			{
				return deflt;
			}
			set
			{
				this.deflt = value;
			}
		}

	}

}
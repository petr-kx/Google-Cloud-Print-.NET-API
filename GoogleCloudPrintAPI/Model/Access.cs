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
	public class Access
	{
	    public virtual string Membership { get; set; }


	    public virtual string Email { get; set; }


	    public virtual string Name { get; set; }


	    public virtual string Role { get; set; }


	    public virtual string USER { get; set; }


	    public virtual bool Is_pending { get; set; }


	    public override string ToString()
		{
			return "{" + "\n\t membership = " + Membership + "," + "\n\t email = " + Email + "," + "\n\t name = " + Name + "," + "\n\t role = " + Role + "," + "\n\t USER=" + USER + "," + "\n\t is_pending=" + Is_pending + "\n}";
		}
	}

}
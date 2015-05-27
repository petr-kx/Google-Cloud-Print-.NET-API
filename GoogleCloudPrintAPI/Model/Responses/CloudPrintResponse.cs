/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace GoogleCloudPrintAPI.Model.Responses
{

	/// 
	/// <summary>
	/// @author jittagorn pitakmetagoon
	/// </summary>
	public class CloudPrintResponse
	{
	    public virtual bool Success { get; set; }


	    public virtual string Message { get; set; }


	    public virtual string Xsrf_token { get; set; }
	}

}
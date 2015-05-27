using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GoogleCloudPrintAPI.Exceptions;


namespace GoogleCloudPrintAPI.Helpers
{
    public static class HttpHelper
    {
        public static string HttpPost(string uri, string parameters, GoogleAuthentication auth = null)
        {
            WebRequest req = WebRequest.Create(uri);
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            if (auth != null)
            {
                req.Headers.Set(HttpRequestHeader.Authorization, "GoogleLogin auth=" + auth.Auth);
                req.Headers.Add("X-CloudPrint-Proxy", auth.Source);
            }

            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            req.ContentLength = bytes.Length;
            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            WebResponse resp = req.GetResponse();

            var rStream = resp.GetResponseStream();
            if (rStream != null)
            {
                var sr = new StreamReader(rStream);
                return sr.ReadToEnd().Trim();
            }

            throw new CloudPrintException("Http Response was null.");
            
        }

        public static string UploadFilesToRemoteUrl(string uri, string b64, NameValueCollection nvc, string jsTicket, GoogleAuthentication auth, string contentType)
        {
            string boundary = "----------------------------" +
                              DateTime.Now.Ticks.ToString("x");


            var httpWebRequest2 = (HttpWebRequest) WebRequest.Create(uri);
            httpWebRequest2.ContentType = "multipart/form-data; boundary=" +
                                          boundary;
            httpWebRequest2.Method = "POST";
            httpWebRequest2.KeepAlive = true;
            httpWebRequest2.Credentials =
            CredentialCache.DefaultCredentials;
            httpWebRequest2.Headers.Set(HttpRequestHeader.Authorization, "GoogleLogin auth=" + auth.Auth);
            httpWebRequest2.Headers.Set("X-CloudPrint-Proxy", auth.Source);


            Stream memStream = new MemoryStream();

            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");


            string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";


            foreach (string key in nvc.Keys)
            {
                string formitem = string.Format(formdataTemplate, key, nvc[key]);    
                byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }

            memStream.Write(boundarybytes, 0, boundarybytes.Length);

            const string headerTemplate = "Content-Disposition: form-data; name=\"content\"\r\n\r\ndata:{0}; base64,{1}";
            string header = string.Format(headerTemplate, contentType, b64);

            byte[] headerbytes = Encoding.UTF8.GetBytes(header);

            memStream.Write(headerbytes, 0, headerbytes.Length);

            var endBoundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--");
            memStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);

            httpWebRequest2.ContentLength = memStream.Length;
            Stream requestStream = httpWebRequest2.GetRequestStream();
            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();


            WebResponse webResponse2 = httpWebRequest2.GetResponse();

            Stream stream2 = webResponse2.GetResponseStream();
            if (stream2 != null)
            {
                var reader2 = new StreamReader(stream2);

                string response = reader2.ReadToEnd();

                webResponse2.Close();

                return response;
            }

            throw new CloudPrintException("Http Response was null.");
        }


        private static bool ValidateRemoteCertificate(
                object sender,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors policyErrors)
        {
            return true;
            //if (Convert.ToBoolean(ConfigurationManager.AppSettings["IgnoreSslErrors"]))
            //{
            //    // allow any old dodgy certificate...
            //    return true;
            //}
            //else
            //{
            //    return policyErrors == SslPolicyErrors.None;
            //}
        }

    }
}

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Text;
using GoogleCloudPrintAPI.Exceptions;
using GoogleCloudPrintAPI.Helpers;
using GoogleCloudPrintAPI.Model;
using GoogleCloudPrintAPI.Model.Responses;
using Newtonsoft.Json;

namespace GoogleCloudPrintAPI
{

    /// 
    /// <summary>
    /// @author jittagorn pitakmetagoon </summary>
    /// <seealso cref= https://developers.google.com/cloud-print/>/ </seealso>
    public class GoogleCloudPrint
    {
        private const string CLOUD_PRINT_URL = "https://www.google.com/cloudprint";
        private const string CLOUD_PRINT_SERVICE = "cloudprint";
        private GoogleAuthentication authen;

        /// <summary>
        /// For connect to Google Cloud Print Service and Google Talk for real time
        /// job notify<br/><br/>
        /// </summary>
        /// <param name="email"> Google Account or Email Address </param>
        /// <param name="password"> Email Password </param>
        /// <param name="source"> Short string identifying your application, for logging
        /// purposes. This string take from :
        /// "companyName-applicationName-VersionID". </param>
        /// <exception cref="CloudPrintAuthenticationException"> </exception>
        public virtual void connect(string email, string password, string source)
        {
            try
            {
                //Google Cloud Print Service Authen
                authen = new GoogleAuthentication(CLOUD_PRINT_SERVICE);
                authen.login(email, password, source);

                Debug.Write("Connected to {}", GoogleAuthentication.LOGIN_URL + "[" + CLOUD_PRINT_SERVICE + "] ...");
            }

            catch (Exception ex)
            {
                throw new CloudPrintAuthenticationException(ex.Message);
            }
        }

        /// <summary>
        /// open connection to target service
        /// </summary>
        /// <param name="serviceAndParameters"> </param>
        /// <param name="entity"> </param>
        /// <returns> service response </returns>
        /// <exception cref="CloudPrintException"> </exception>
        private string openConnection(string serviceAndParameters)
        {
            string response;
            try
            {
                string uri = CLOUD_PRINT_URL + serviceAndParameters;
                response = HttpHelper.HttpPost(uri, "", authen);
            }
            catch (Exception ex)
            {
                throw new CloudPrintException(ex.Message);
            }

            return response;
        }

        private string openConnectionForSubmit(string serviceAndParameters, NameValueCollection nvc,
                                               string b64, string ticket, string contentType)
        {
            string response;
            try
            {
                string uri = CLOUD_PRINT_URL + serviceAndParameters;
                //response = HttpHelper.HttpPostWithMultipart(uri, entity, authen);
                response = HttpHelper.UploadFilesToRemoteUrl(uri, b64, nvc, ticket, authen, contentType);
            }
            catch (Exception ex)
            {
                throw new CloudPrintException(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// public PrinterInformationResponse getPrinterInformation(String printerId) throws CloudPrintException {
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/appInterfaces#printer'>/printer</a></b><br/>
        /// The /printer interface retrieves the capabilities of the specified
        /// printer.<br/></br><br/>
        /// <b>Reponse</b><br/>
        /// The response is a list of attributes about the requested printer, in
        /// JSON. Fields returned include:<br/>
        /// - <b>name</b><br/>
        /// - <b>description</b><br/>
        /// - <b>proxy</b> connector through which this printer is run, if any<br/>
        /// - <b>status</b><br/>
        /// - <b>tags</b><br/>
        /// - <b>capabilities</b><br/>
        /// - <b>access</b> a list of access roles<br/>
        /// - <b>connectionStatus</b> printer's connection status, which can be on of
        /// {
        /// </summary>
        /// <seealso cref= PrinterStatus}<br/><br/>
        /// Note that this field is only returned if printer_connection_status is set
        /// to true.<br/>
        /// </seealso>
        /// <param name="printerId"> The ID of the printer whose capabilities we require. The
        /// printer must be accessible (either owned or shared with) the user
        /// authenticated by the current authenticated session.
        /// </param>
        /// <returns> PrinterInformationResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual PrinterInformationResponse getPrinterInformation(string printerId)
        {
            string response = openConnection("/printer?output=json&use_cdd=true&printerid=" + printerId);
            var myDeserializedObj = (PrinterInformationResponse) JsonConvert.DeserializeObject(response, typeof(PrinterInformationResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/appInterfaces#printer'>/printer</a></b><br/>
        /// The /printer interface retrieves the capabilities of the specified
        /// printer.<br/></br><br/>
        /// <b>Reponse</b><br/>
        /// The response is a list of attributes about the requested printer, in
        /// JSON. Fields returned include:<br/>
        /// - <b>name</b><br/>
        /// - <b>description</b><br/>
        /// - <b>proxy</b> connector through which this printer is run, if any<br/>
        /// - <b>status</b><br/>
        /// - <b>tags</b><br/>
        /// - <b>capabilities</b><br/>
        /// - <b>access</b> a list of access roles<br/>
        /// - <b>connectionStatus</b> printer's connection status, which can be on of
        /// {
        /// </summary>
        /// <seealso cref= PrinterStatus}<br/><br/>
        /// Note that this field is only returned if printer_connection_status is set
        /// to true.<br/>
        /// </seealso>
        /// <param name="printerId"> The ID of the printer whose capabilities we require. The
        /// printer must be accessible (either owned or shared with) the user
        /// authenticated by the current authenticated session.
        /// </param>
        /// <param name="status"> A Boolean that specifies whether or not to return the
        /// printer's connectionStatus field.
        /// 
        /// @return </param>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual PrinterInformationResponse getPrinterInformation(string printerId, PrinterStatus status)
        {
            return getPrinterInformation(printerId + "&printer_connection_status=" + status);
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/appInterfaces#search'>/search</a></b><br/>
        /// The /search interface returns a list of printers accessible to the
        /// authenticated authenticated user, taking an optional search query as a
        /// parameter. Note that by default, /search will not include printers that
        /// have been offline for a long time (i.e. whose connectionStatus is
        /// DORMANT). This behavior can be overridden if ALL or DORMANT is passed as
        /// the value of the optional connection_status parameter.<br/><br/>
        /// <b>Response</b><br/>
        /// The response is a list of printers, in JSON. All fields are listed,
        /// except for capabilities which must be retrieved using a call to
        /// /printerCapabilities.
        /// </summary>
        /// <param name="query"> (optional) If q is specified, then only printers
        /// corresponding to the query will be returned. If q is not specified, then
        /// all printers accessible (owned or shared with) the authenticated user
        /// will be returned. The API looks for an approximate match between q and
        /// the name and tag fields (ie. [field] == %q%). Thus, setting q = "^recent"
        /// will return the list of recently used printers. Setting q = ^own or q =
        /// ^shared" will return the list of printers either owned by or shared with
        /// this user.
        /// </param>
        /// <param name="status"> (optional) If connection_status is specified, then only
        /// printers whose connection status matches the supplied value will be
        /// returned. You may provide one of the four values listed above or you may
        /// specify ALL, which will match all printers, including those marked as
        /// DORMANT.
        /// </param>
        /// <returns> SearchPrinterResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual SearchPrinterResponse searchPrinter(string query, PrinterStatus status)
        {
            string response = openConnection((new StringBuilder()).Append("/search?output=json").Append("&q=").Append(query).Append("&connection_status=").Append(status).ToString());
            var myDeserializedObj = (SearchPrinterResponse)JsonConvert.DeserializeObject(response, typeof(SearchPrinterResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/appInterfaces#search'>/search</a></b><br/>
        /// The /search interface returns a list of printers accessible to the
        /// authenticated authenticated user, taking an optional search query as a
        /// parameter. Note that by default, /search will not include printers that
        /// have been offline for a long time (i.e. whose connectionStatus is
        /// DORMANT). This behavior can be overridden if ALL or DORMANT is passed as
        /// the value of the optional connection_status parameter.<br/><br/>
        /// <b>Response</b><br/>
        /// The response is a list of printers, in JSON. All fields are listed,
        /// except for capabilities which must be retrieved using a call to
        /// /printerCapabilities.
        /// </summary>
        /// <returns> SearchPrinterResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual SearchPrinterResponse searchPrinters()
        {
            string response = openConnection("/search?output=json&use_cdd=true");
            var myDeserializedObj = (SearchPrinterResponse)JsonConvert.DeserializeObject(response, typeof(SearchPrinterResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/appInterfaces#jobs'>/jobs</a></b><br/>
        /// The /jobs interface retrieves the status of print jobs for a
        /// user.<br/><br/>
        /// <b>Response</b><br/>
        /// The response is a list of print jobs, in JSON. Fields listed are the
        /// following:<br/>
        /// - <b>id</b> print job ID<br/>
        /// - <b>printerid</b> printer’s GCP ID<br/>
        /// - <b>title</b> document title<br/>
        /// - <b>contentType</b> document content type (MIME type)<br/>
        /// - <b>fileUrl</b><br/>
        /// - <b>ticketUrl</b><br/>
        /// - <b>createTime</b> time stamp of when the print job was created<br/>
        /// - <b>updateTime</b> time stamp of when the print job status was last
        /// updated<br/>
        /// - <b>status</b> print job status (see below for a list of possible
        /// status)<br/>
        /// - <b>errorCode</b> contains an error code if the print job status is
        /// ‘ERROR’, and otherwise is null<br/>
        /// - <b>message</b><br/>
        /// - <b>tags</b>
        /// Print jobs are tagged as ^own if the user is the owner of the job, and
        /// ^shared if the job was merely shared with the user.<br/><br/>
        /// 
        /// Note that the status of a print job can be any of the following:<br/>
        /// 
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QUEUED - Job just added
        /// and has not yet been downloaded<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IN_PROGRESS - Job
        /// downloaded and has been added to the client-side native printer
        /// queue<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DONE - Job printed
        /// successfully<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ERROR - Job cannot be
        /// printed due to an error<br/>
        /// </summary>
        /// <returns> JobResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual JobResponse getJobs()
        {
            string response = openConnection("/jobs?output=json");
            var myDeserializedObj = (JobResponse)JsonConvert.DeserializeObject(response, typeof(JobResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/appInterfaces#jobs'>/jobs</a></b><br/>
        /// The /jobs interface retrieves the status of print jobs for a
        /// user.<br/><br/>
        /// <b>Response</b><br/>
        /// The response is a list of print jobs, in JSON. Fields listed are the
        /// following:<br/>
        /// - <b>id</b> print job ID<br/>
        /// - <b>printerid</b> printer’s GCP ID<br/>
        /// - <b>title</b> document title<br/>
        /// - <b>contentType</b> document content type (MIME type)<br/>
        /// - <b>fileUrl</b><br/>
        /// - <b>ticketUrl</b><br/>
        /// - <b>createTime</b> time stamp of when the print job was created<br/>
        /// - <b>updateTime</b> time stamp of when the print job status was last
        /// updated<br/>
        /// - <b>status</b> print job status (see below for a list of possible
        /// status)<br/>
        /// - <b>errorCode</b> contains an error code if the print job status is
        /// ‘ERROR’, and otherwise is null<br/>
        /// - <b>message</b><br/>
        /// - <b>tags</b>
        /// Print jobs are tagged as ^own if the user is the owner of the job, and
        /// ^shared if the job was merely shared with the user.<br/><br/>
        /// 
        /// Note that the status of a print job can be any of the following:<br/>
        /// 
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QUEUED - Job just added
        /// and has not yet been downloaded<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IN_PROGRESS - Job
        /// downloaded and has been added to the client-side native printer
        /// queue<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DONE - Job printed
        /// successfully<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ERROR - Job cannot be
        /// printed due to an error<br/>
        /// </summary>
        /// <param name="printerId"> (optional) If a printer ID is specified, the print jobs
        /// for that printer will be retrieved (instead of retrieving the jobs for
        /// the user whose session this is).
        /// </param>
        /// <returns> JobResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual JobResponse getJobOfPrinter(string printerId)
        {
            string response = openConnection("/jobs?output=json&printerid=" + printerId);
            var myDeserializedObj = (JobResponse)JsonConvert.DeserializeObject(response, typeof(JobResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/proxyinterfaces#delete'>/delete</a></b><br/>
        /// This interface is used to delete a printer from Google Cloud
        /// Print.<br/><br/>
        /// Response<br/>
        /// The response object contains a Boolean success indicator and a
        /// message.<br/>
        /// </summary>
        /// <param name="printerId"> Unique printer identification (generated by Google Cloud
        /// Print). </param>
        /// <returns> DeletePrinterResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual DeletePrinterResponse deletePrinter(string printerId)
        {
            string response = openConnection("/delete?output=json&printerid=" + printerId);
            var myDeserializedObj = (DeletePrinterResponse)JsonConvert.DeserializeObject(response, typeof(DeletePrinterResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b>/fetch</b><br/>
        /// This interface is used to fetch the next available job for the specified
        /// printer.<br/><br/>
        /// <b>Response</b><br/>
        /// The response object contains a Boolean success indicator and a list of
        /// jobs. The list would contain only the jobs that are in QUEUED state.<br/>
        /// <br/>
        /// <b>Simple Response</b><br/>
        /// {<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;"success": true,<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;"jobs": [{ <br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"id":
        /// "3432682791683548017",<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"title":
        /// "CloudPrint_Architecture.pdf",<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"status": "QUEUED", <br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"fileUrl":"http://docs.google.com/printing/download?id\u003d3432682791683548017",<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"ticketUrl":"http://docs.google.com/printing/fetch?output\u003dxml\u0026jobid\u003d3432682791683548017"<br/>
        /// &nbsp;&nbsp;&nbsp;&nbsp;}]<br/> }<br/><br/>
        /// <b>Note</b>: The URLs for downloading the file/data to be printed and the
        /// print job ticket are absolute URLs, and they might not point to the same
        /// host as the URL for the /fetch interface.<br/><br/>
        /// 
        /// The ticketUrl field in the response points to a job ticket that can be in
        /// XPS (<a
        /// href='http://en.wikipedia.org/wiki/Open_XML_Paper_Specification'>XML
        /// Paper Specification</a>) or PPD (<a
        /// href='http://en.wikipedia.org/wiki/PostScript_Printer_Description'>Postscript
        /// Printer Description</a>) format. In the future, other job ticket formats
        /// may be supported. The fileUrl field in the response points to the data to
        /// be printed. As the file download is an HTTP request, the printer /
        /// software connector should specify MIME types it can accept to print in
        /// the Accept header as defined by HTTP protocol. Google Cloud Print will
        /// try to convert the print data to a format acceptable to the printer /
        /// software connector.<br/><br/>
        /// 
        /// When performing a request to fetch the fileUrl as a PWG-raster document,
        /// we also support an optional query parameter skippages. When skippages=N
        /// is specified, the first N pages of the PWG-raster document are skipped.
        /// Page skipping is relative to the PWG-raster document after page
        /// reordering and not relative to the original document. This parameter can
        /// be used by the printer if it needs to resume printing pages from some
        /// point, say after a paper jam. The parameter is for PWG-raster documents
        /// only and has no effect if you download documents in PDF format.
        /// </summary>
        /// <param name="printerId"> Unique printer identification (generated by Google Cloud
        /// Print). </param>
        /// <returns> FecthJobResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual FecthJobResponse fetchJob(string printerId)
        {
            string response = openConnection("/fetch?output=json&printerid=" + printerId);
            var myDeserializedObj = (FecthJobResponse)JsonConvert.DeserializeObject(response, typeof(FecthJobResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/appInterfaces#deletejob'>/deletejob</a></b><br/></br>
        /// The /deletejob interface deletes the given print job.<br/><br/>
        /// <b>Response</b><br/>
        /// The response object contains a Boolean success indicator and a message.
        /// </summary>
        /// <param name="jobId"> The ID of the print job to be deleted. The print job must be
        /// owned by the user authenticated by the current authenticated session. </param>
        /// <returns> DeleteJobResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual DeleteJobResponse deleteJob(string jobId)
        {
            string response = openConnection("/deletejob?output=json&jobid=" + jobId);
            var myDeserializedObj = (DeleteJobResponse)JsonConvert.DeserializeObject(response, typeof(DeleteJobResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/proxyinterfaces#control'>/control</a></b><br/>
        /// This interface can be used by the printer / software connector to update
        /// Google Cloud Print about the status of the print job on the printer
        /// device. The code and message parameters are useful for displaying helpful
        /// information to the user via the user interface. These parameters are not
        /// used for any control, disabling, or filtering of the print job or the
        /// printer.<br/><br/>
        /// </summary>
        /// <param name="jobid"> Unique job identification (generated by server). </param>
        /// <param name="status"> { </param>
        /// <seealso cref= JobStatus} </seealso>
        /// <param name="code"> Error code string or integer (as returned by the printer or
        /// OS) if the status is ERROR. </param>
        /// <param name="message"> Error message string (as returned by the printer or OS) if
        /// the status is ERROR </param>
        /// <returns> The response object contains a Boolean success indicator and a
        /// message. </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual ControlJobResponse controlJob(string jobid, JobStatus status, int code, string message)
        {
            string response = openConnection((new StringBuilder()).Append("/control?output=json").Append("&jobid=").Append(jobid).Append("&status=").Append(status).Append("&code=").Append(code).Append("&message=").Append(message).ToString());
            var myDeserializedObj = (ControlJobResponse)JsonConvert.DeserializeObject(response, typeof(ControlJobResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/proxyinterfaces#list'>/list</a></b><br/>
        /// This interface provides a listing of all the printers for the given user.
        /// It can be used to compare the printers registered and available locally.
        /// If a software connector is connected to multiple printers, this interface
        /// is useful to keep the local printers and printers registered with Google
        /// Cloud Print in sync. With this interface, the software connector does not
        /// need to maintain a state or mapping of the local printers and needs to
        /// store only the unique proxy ID required as a parameter.<br/><br/>
        /// 
        /// Response<br/>
        /// The response object contains a Boolean success indication and a list of
        /// printer objects. If there was a valid software connector specified in the
        /// request then only the printers assigned to that software connector are
        /// returned. The printer object contains id, name, and proxy fields as shown
        /// in the sample output below. Additional details of the printer (for
        /// example, capabilities) can be added to the output using the objects
        /// parameter described in <a
        /// href='https://developers.google.com/cloud-print/docs/proxyinterfaces#commonoutput'>Common
        /// Output Control Parameters and Values.</a><br/>
        /// </summary>
        /// <param name="proxy"> Identification of the proxy, as submitted while registering
        /// the printer. </param>
        /// <returns> ListPrinterResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual ListPrinterResponse listPrinter(string proxy)
        {
            string response = openConnection("/list?output=json&proxy=" + proxy);
            var myDeserializedObj = (ListPrinterResponse)JsonConvert.DeserializeObject(response, typeof(ListPrinterResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// For share printer to target email
        /// </summary>
        /// <param name="printerId"> Unique printer identification (generated by Google Cloud
        /// Print). </param>
        /// <param name="email"> Google Account or Google Email for share </param>
        /// <returns> SharePrinterResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual SharePrinterResponse sharePrinter(string printerId, string email)
        {
            string response = openConnection((new StringBuilder()).Append("/share?output=json").Append("&printerid=").Append(printerId).Append("&email=").Append(email).Append("&role=").Append(RoleShare.APPENDER).ToString());
            var myDeserializedObj = (SharePrinterResponse)JsonConvert.DeserializeObject(response, typeof(SharePrinterResponse));
            return myDeserializedObj;
        }

        /// <summary>
        /// <b>/ticket</b><br/>
        /// Get job ticket from Google Cloud Print<br/><br/>
        /// <b>Response</b><br/>
        /// XML format : print job detail such as<br/>
        /// - document collate<br/>
        /// - page output color<br/>
        /// - page orientation<br/>
        /// - page media size<br/>
        /// - duplex page<br/>
        /// - copies document<br/>
        /// - etc.
        /// </summary>
        /// <param name="ticketUrl"> The ticketUrl field in the response points to a job
        /// ticket that can be in XPS (<a
        /// href='http://en.wikipedia.org/wiki/Open_XML_Paper_Specification'>XML
        /// Paper Specification</a>) or PPD (<a
        /// href='http://en.wikipedia.org/wiki/PostScript_Printer_Description'>Postscript
        /// Printer Description</a>) format. In the future, other job ticket formats
        /// may be supported. The fileUrl field in the response points to the data to
        /// be printed. As the file download is an HTTP request, the printer /
        /// software connector should specify MIME types it can accept to print in
        /// the Accept header as defined by HTTP protocol. Google Cloud Print will
        /// try to convert the print data to a format acceptable to the printer /
        /// software connector.
        /// 
        /// @return </param>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual string getJobTicket(string ticketUrl)
        {
            if (ticketUrl != null)
            {
                ticketUrl = ticketUrl.Replace(CLOUD_PRINT_URL, "");
            }

            return openConnection(ticketUrl);
        }

        /// <summary>
        /// <b><a
        /// href='https://developers.google.com/cloud-print/docs/appInterfaces#submit'>/submit</a></b><br/>
        /// The /submit service interface is used to send print jobs to the GCP
        /// service. Upon initialization, the status of the print job will be QUEUED.
        /// The print job is created and the appropriate printer is notified of its
        /// existence. The status of the print job can then be tracked using /jobs,
        /// as described below.<br/><br/>
        /// </summary>
        /// <param name="sb"> has attribute following : <br/><br/>
        /// <b>printerid</b> Unique printer identification (generated by Google Cloud
        /// Print). To get valid printer IDs for a given user, retrieve the list of
        /// available printers for that Google Account by querying the /search
        /// service interface.<br/><br/>
        /// <b>title</b> Title of the print job, to be used within GCP.<br/><br/>
        /// <b>capabilities</b> Printer capabilities (XPS or PPD). Each GCP printer
        /// has, associated with it, a list of pair-value capabilities representing
        /// printer-specific attributes (available printing formats, copy count,
        /// etc.) Capabilities for a given printer can be retrieved using the /list
        /// service interface. These retrieved capabilities can then be used to
        /// specify desired options on the print job (for instance, print 5 copies
        /// instead of the default 1, or print duplex instead of single
        /// sided).<br/><br/>
        /// <b>content</b> Document to print.<br/><br/>
        /// <b>contentType</b> Document type. Currently, valid document types are:
        /// url, application/pdf, image/jpeg, or image/png. If contentType = url, the
        /// URL should point to a publicly accessible page (there should be no
        /// necessary authentication, cookies, etc.) The linked resource can be a
        /// PDF, JPG, or PNG file, but we recommend PDF for highest
        /// fidelity.<br/><br/>
        /// <b>tag</b> One or more tags to add to the print job. You can attach a set
        /// of unique tags to a print job, and these will be available to the printer
        /// to which the print job is submitted. This feature may be useful if your
        /// application both sends and receives print jobs.<br/>
        /// </param>
        /// <returns> SubmitJobResponse </returns>
        /// <exception cref="CloudPrintException"> </exception>
        public virtual SubmitJobResponse submitJob(SubmitJob sb)
        {
            string response;
            try
            {
                var nvc = new NameValueCollection {{"contentType", "dataUrl"}, {"title", sb.Title}};
                var settings = new JsonSerializerSettings {ContractResolver = new LowercaseContractResolver()};
                string jsTicket = JsonConvert.SerializeObject(sb.Ticket, Formatting.Indented, settings);
                nvc.Add("ticket", jsTicket);
                byte[] document = File.ReadAllBytes(sb.FileToPrint.FullName);
                string b64 = Convert.ToBase64String(document);
                response = openConnectionForSubmit("/submit?output=json&printerid=" + sb.PrinterId, nvc, b64, jsTicket, sb.ContentType);
            }
            catch (Exception ex)
            {
                throw new CloudPrintException(ex.Message);
            }

            var myDeserializedObj = (SubmitJobResponse)JsonConvert.DeserializeObject(response, typeof(SubmitJobResponse));
            return myDeserializedObj;
        }

    }
}
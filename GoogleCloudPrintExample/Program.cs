using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using GoogleCloudPrintAPI;
using GoogleCloudPrintAPI.Model;
using GoogleCloudPrintAPI.Model.Responses;
using Newtonsoft.Json;

namespace GoogleCloudPrintExample
{
    class Program
    {
        private static readonly GoogleCloudPrint cloudPrint = new GoogleCloudPrint();
        
        const string email = "YOUR_EMAIL";
        const string password = "YOUR_PASSWORD";
        const string source = "geniustree-cloudprint-1.0";

        static void Main()
        {
            cloudPrint.connect(email, password, source);
            //getPrinterInformation("__google__docs");
            //getPrinterInformation("dc6929f5-8fdc-5228-1e73-c9dee3298445", PrinterStatus.ONLINE);
            //searchPrinter("Snagit", PrinterStatus.ALL);
            //searchAllPrinters();
            //getJobs();
            //getJobOfPrinter("dc6929f5-8fdc-5228-1e73-c9dee3298445");
            //deletePrinter("63a6de9f-672f-4b79-908d-749420fdd899");
            submitJob("7036f7a2-a984-b6b6-19b6-a5a182fe7358");
        }

        public static void getPrinterInformation(String printerId) {
            PrinterInformationResponse response = cloudPrint.getPrinterInformation(printerId);
            
            if (!response.Success) {
                Debug.Write("message = > {}", response.Message);
                return;
            }

            foreach (Printer printer in response.Printers)
            {
                Debug.Write("message = > {}", printer.ToString());
            }

        }

        public static void searchPrinter(String query, PrinterStatus status)
        {
            SearchPrinterResponse response = cloudPrint.searchPrinter(query, status);
            if (!response.Success)
            {
                Debug.Write("message = > {}", response.Message);
                return;
            }

            foreach (Printer printer in response.Printers)
            {
                Debug.Write("message = > {}", printer.ToString());
            }
        }

        public static void searchAllPrinters()
        {
            SearchPrinterResponse response = cloudPrint.searchPrinters();
            if (!response.Success)
            {
                Debug.Write("message = > {}", response.Message);
                return;
            }

            foreach (Printer printer in response.Printers)
            {
                Debug.Write("message = > {}", printer.ToString());
            }
        }

        public static void getJobs()
        {
            JobResponse response = cloudPrint.getJobs();
            if (!response.Success)
            {
                Debug.Write("message = > {}", response.Message);
                return;
            }

            foreach (Job job in response.Jobs)
            {
                Debug.Write("job response => {}", job.ToString());
            }
        }

        public static void getJobOfPrinter(string printerId)
        {
            JobResponse response = cloudPrint.getJobOfPrinter(printerId);
            if (!response.Success)
            {
                Debug.Write("message = > {}", response.Message);
                return;
            }

            foreach (Job job in response.Jobs)
            {
                Debug.Write("job response => {}", job.ToString());
            }
        }

        public static void getPrinterInformation(string printerId, PrinterStatus status)
        {
            PrinterInformationResponse response = cloudPrint.getPrinterInformation(printerId, status);
            if (!response.Success)
            {
                Debug.Write("message = > {}", response.Message);
                return;
            }

            foreach (Printer printer in response.Printers)
            {
                Debug.Write("printer information response => {}", printer.ToString());
            }
        }

        public static void deletePrinter(string printerId)
        {
            DeletePrinterResponse response = cloudPrint.deletePrinter(printerId);
            Debug.Write("delete printer response => {}", response.Success + ", " + response.Message);
        }

        public static void fetchJob(string printerId)
        {
            FecthJobResponse response = cloudPrint.fetchJob(printerId);
            Debug.Write("fetch job response => {}", response.Success + ", " + response.Message);
        }

        public static void deleteJob(string jobId)
        {
            DeleteJobResponse response = cloudPrint.deleteJob(jobId);
            Debug.Write("delete job response => {}", response.Success + ", " + response.Message);
        }

        public static void controlJob(string jobid, JobStatus status, int code, string message)
        {
            ControlJobResponse response = cloudPrint.controlJob(jobid, status, code, message);
            Debug.Write("control printer response => {}", response.Success + ", " + response.Message);
        }

        public static void sharePrinter(string printerId, string emailToShare)
        {
            SharePrinterResponse response = cloudPrint.sharePrinter(printerId, emailToShare);
            Debug.Write("share printer response => {}", response.Success + ", " + response.Message);
        }

        public static void listPrinter(string proxy)
        {
            ListPrinterResponse response = cloudPrint.listPrinter(proxy);
            Debug.Write("list printer response => {}", response.Success + ", " + response.Message);
        }

        public static void getJobTicket(string ticketUrl)
        {
            string response = cloudPrint.getJobTicket(ticketUrl);
            Debug.Write("job ticket response => {}", response);
        }

        public static void submitJob(string printerId)
        {
            var fileToPrint = new FileInfo("C:\\tests\\testImage.png");
            string jsonTicket = File.ReadAllText("C:\\tests\\submitJobTicketRequest.json");
            var ticket = (Ticket)JsonConvert.DeserializeObject(jsonTicket, typeof(Ticket));
            string json = JsonConvert.SerializeObject(ticket);
            Debug.Write("json => {}", json);
            
            var sb = new SubmitJob
                {
                    FileToPrint = fileToPrint,
                    ContentType = "image/png",
                    PrinterId = printerId,
                    Tag = new List<string> {"koalar", "hippo", "cloud"},
                    Ticket = ticket,
                    Title = "testImage.png"
                };
            SubmitJobResponse response = cloudPrint.submitJob(sb);
            Debug.Write("submit job response => {}", response.Success + "," + response.Message);
            Debug.Write("submit job id => {}", response.Job.Id);
        }
    }
}

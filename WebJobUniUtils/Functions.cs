using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;

namespace WebJobUniBLL {
    public class Functions {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        //public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log) {
        //    log.WriteLine(message);
        //}

        public static void WriteMsgBlob(String msg, string counter) {//
            try {
                string conStrKey1 = "DefaultEndpointsProtocol=https;AccountName=blobazurestorage1;AccountKey=hk2xEdiEjmO9ltbLGJQgtRPx7Wm739mNM/KuXKjsjZGDS+Jh0X5t+qwBXbif1iMD5VVwzutrhaXZQJ35nIggMQ==;BlobEndpoint=https://blobazurestorage1.blob.core.windows.net/";
                //string conStrKey2 = "DefaultEndpointsProtocol=https;AccountName=blobazurestorage1;AccountKey=ZLolikai56iIH3KjwaRVDd2XP99RMQn5hvvs8k8V6AEXmi3i5PrV62BKcLoRuCRgx/gEX9KrE7UMDjyKt/u9gg==;BlobEndpoint=https://blobazurestorage1.blob.core.windows.net/";

                //Create an instance of CloudStorageAccount.
                //This represents a Windows Azure Storage account.
          //      CloudStorageAccount storageAccount = CloudStorageAccount.Parse(conStrKey1);

                //Create an instance of CreateCloudBlobClient.
                //Provides a client - side logical representation of the Windows Azure Blob service. This client is used to configure and execute requests against the Blob service.
           //     CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                //Get a container in the Windows Azure Blob service. Create the container if it does not exist. 
           //     CloudBlobContainer container = blobClient.GetContainerReference("blobcontainer1");
          //      container.CreateIfNotExists();

                //Gets a reference to a block blob in the container and upload a string text to it.
            //    CloudBlockBlob blob = container.GetBlockBlobReference("survey"+ counter + ".txt");
            //    blob.UploadText(msg );
            }
            catch (Exception e) {
                //Console.WriteLine("Saving to blob failed. " + e.Message);
                System.Diagnostics.Debug.Print("Saving to blob failed. " + e.Message);
                //  throw;
            }
        }

        //The next step is to send the results by mail.This is done by the following function:
        public static void SendEmail(string msg) {
            try {
                var portNumber = 8080;
                bool enableSSL = false;

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("emailFrom");
                mail.To.Add("emailTo");
                mail.Subject = "subject";
                mail.Body = msg;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtpAddress", portNumber)) {
                    smtp.Credentials = new NetworkCredential("emailFrom", "password");
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                    Console.WriteLine("Email sent to " + "emailTo" + " at " + DateTime.Now);
                }
            }
            catch (Exception e) {
                Console.WriteLine("Email failed " + e.Message);
                throw;
            }
        }

        public static void WriteToBlob(string salesreport) {
            try {
                string acs = "DefaultEndpointsProtocol=https;AccountName=xxx;AccountKey=xxx";

                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(acs);
                //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                //CloudBlobContainer container = blobClient.GetContainerReference("salesinfo");
                //container.CreateIfNotExists();
                //CloudBlockBlob blob = container.GetBlockBlobReference("DailyReport" + DateTime.Now + ".txt");
                //blob.UploadText(salesreport);

                Console.WriteLine("File saved successfully"); ;

            }
            catch (Exception e) {
                Console.WriteLine("Saving to blob failed " + e.Message);

                throw;
            }
        }
    }
}

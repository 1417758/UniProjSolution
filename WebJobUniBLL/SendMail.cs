using System;
using System.Text;
using WebJobUniUtils;
using System.Net.NetworkInformation;
using System.Net.Mail;
//------------------------------------------------------------------------------------------------------
// <copyright file="SendMail.vb"  company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------------
namespace WebJobUniBLL {
    public class SendMail {


        private SendMail() {
        }

        public static bool Send(string Body, string Subject, DeliveryNotificationOptions DeliveryOptions, MailPriority Priority, MailAddress ToMail, MailAddress FromMail, string AttachFile, MailAddress bcc, MailAddress CC) {
            MailMessage mail = new MailMessage();
            // Check that the connection is good
            if (!DoesPing("securesend.lawyersonline.co.uk")) {
                //Need to try another time
                //set flag for retry?
                return false;
            }

            using (mail) {
                try {
                    var _with1 = mail;
                    if ((AttachFile != null) && System.IO.File.Exists(AttachFile)) {
                        //check that file exists Throw exception?
                        Attachment item = new Attachment(AttachFile);
                        _with1.Attachments.Add(item);
                    }
                    if ((bcc != null))
                        _with1.Bcc.Add(bcc);
                    if ((CC != null))
                        _with1.CC.Add(CC);
                    _with1.BodyEncoding = System.Text.Encoding.Unicode;
                    _with1.To.Add(ToMail);
                    _with1.From = FromMail;
                    _with1.Priority = Priority;
                    _with1.DeliveryNotificationOptions = DeliveryOptions;
                    if ((FromMail != null))
                        _with1.ReplyTo = FromMail;
                    _with1.Sender = FromMail;
                    _with1.Subject = Subject;
                    _with1.Body = Body;
                    _with1.IsBodyHtml = true;
                    SmtpClient SmtpMail = new SmtpClient();
                    var _with2 = SmtpMail;
                    _with2.Host = "securesend.lawyersonline.co.uk";
                    _with2.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _with2.Send(mail);
                    //smtpMail
                    //mail
                    return true;
                }
                catch (Exception ex) {
                    System.Diagnostics.Debug.Print(ex.Message); ExceptionHandling.LogException(ref ex);
                    return false;
                }
            }
            //mail
        }

        private static bool DoesPing(string Address) {
            //http://msdn2.microsoft.com/en-us/vbasic/ms789075.aspx
            bool rv = false;
            if (Address.Trim().Length > 0) {
                try {
                    Ping Ping = new Ping();
                    PingReply reply = Ping.Send(Address);
                    //Show the ping results
                    return (reply.Status == IPStatus.Success);
                }
                catch (PingException ex) {
                    //log something
                    return rv;
                }
            }
            else {
                return rv;
            }
        }

        /// <summary>
        ///      send email to support team if demo user has exceeded one of his/her demo criterias
        /// </summary>
        /// <remarks></remarks>
        public static void SendDemoSummary(string userName, string applicantionName) {
            try {
                if (AppSettings.Settings == null) {
                    throw new Exception("Applications Settings is empty! this means settings.xml needs to be loaded in the application");
                }
                dynamic exceptionHand = AppSettings.Settings;

                StringBuilder message = new StringBuilder();
                var _with3 = message;
                _with3.Append("DEMO user summary:" + Environment.NewLine);
                _with3.Append(userName.ToUpper() + " has exceeded one of his/her DEMO user criteria:" + Environment.NewLine);
                _with3.Append(Environment.NewLine + "current demo user usage is as follows:" + Environment.NewLine);
                //     _with3.Append("Number Of Logins:" + "\t" + Logins.GetLoginsByUserName_SUC(userName).Rows.Count + Environment.NewLine);
                //    _with3.Append("Number Of Forecasts:" + "\t" + Usage.GetUsageByUserNameAndPage(userName, "NewOutput").Rows.Count + Environment.NewLine);
                //    _with3.Append("Demo started on:" + "\t" + Logins.GetUser1stLoginDate(userName) + Environment.NewLine);

                MailAddress toMail = new MailAddress("support@pi-ltd.com");
                MailAddress toCC = new MailAddress(exceptionHand.ExceptionRecipient);
                MailAddress fromMail = new MailAddress("errors@pi-e2-software.com");

                Send(message.ToString(), applicantionName + " - Demo user summary", System.Net.Mail.DeliveryNotificationOptions.None, System.Net.Mail.MailPriority.High, toMail, fromMail, null, null, toCC);

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Error in BLL.sendMail.SendDemoSummary \n" + XMLConstants.DEBUG_ERROR3);
                System.Diagnostics.Debug.Print("Error in BLL.sendMail.SendDemoSummary \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
            }
        }


        /// <summary>
        /// send email
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="mainBody"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool SendEmail(MailAddress fromAddress, MailAddress toAddress, string mainBody, string subject) {

            try {
                //create email message
                DeliveryNotificationOptions DeliveryOptions = DeliveryNotificationOptions.OnFailure;
                System.Net.Mail.MailPriority Priority = MailPriority.Normal;

                string Attachfile = null;
                MailAddress bcc = null;
                MailAddress CC = null;

                //add header (greetings) to body
                dynamic Body = "<p></p>Dear " + toAddress.DisplayName.ToUpperInvariant() + "," + "<p></p>" + mainBody;
                //add footer to body
                Body = Body + "<p></p><br /><br />Kind Regards," + "<p></p><br />" + fromAddress.DisplayName.ToUpperInvariant();


                return SendMail.Send(Body, subject, DeliveryOptions, Priority, toAddress, fromAddress, Attachfile, bcc, CC);


            }
            catch (Exception ex) {
                //do nothing if there is an exception logging an exception - really bad!
                System.Diagnostics.Debug.Print("Error in sending email exception " + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Message);
                ExceptionHandling.LogException(ref ex);
                //UtilsShared.LogException(ex3);
                return false;
            }
        }

    }

}



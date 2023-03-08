using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using HazarHospital.EmailSender;
using System.Reflection.Metadata.Ecma335;

namespace HazarHospital.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public async Task<bool> SendEmail(EmailRequest model)
        {
            Configuration.Default.ApiKey.Clear();
            Configuration.Default.ApiKey.Add("api-key", "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");

            var apiInstance = new TransactionalEmailsApi();
            string SenderName = "Hazar Hospital";
            string SenderEmail = "femadeen@gmail.com";
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
            string ToEmail = model.ReceiverEmailAdrress;
            string ToName = model.ReceiverName;
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);
            string BccName = "Janice Doe";
            string BccEmail = "example2@example2.com";
            SendSmtpEmailBcc BccData = new SendSmtpEmailBcc(BccEmail, BccName);
            List<SendSmtpEmailBcc> Bcc = new List<SendSmtpEmailBcc>();
            Bcc.Add(BccData);
            string CcName = "John Doe";
            string CcEmail = "example3@example2.com";
            SendSmtpEmailCc CcData = new SendSmtpEmailCc(CcEmail, CcName);
            List<SendSmtpEmailCc> Cc = new List<SendSmtpEmailCc>();
            Cc.Add(CcData);
            string HtmlContent = $"<html><body><h1>{model.Message}</h1></body></html>";
            string TextContent = null;
            string Subject = model.Subject;
            string ReplyToName = "Hazar Hospita";
            string ReplyToEmail = "femadeen@gmail.com";
            SendSmtpEmailReplyTo ReplyTo = new SendSmtpEmailReplyTo(ReplyToEmail, ReplyToName);
            string AttachmentUrl = null;
            string stringInBase64 = "aGVsbG8gdGhpcyBpcyB0ZXN0";
            byte[] Content = System.Convert.FromBase64String(stringInBase64);
            string AttachmentName = "test.txt";
            SendSmtpEmailAttachment AttachmentContent = new SendSmtpEmailAttachment(AttachmentUrl, Content, AttachmentName);
            List<SendSmtpEmailAttachment> Attachment = new List<SendSmtpEmailAttachment>();
            Attachment.Add(AttachmentContent);
            JObject Headers = new JObject();
            Headers.Add("Some-Custom-Name", "unique-id-1234");
            long? TemplateId = null;
            JObject Params = new JObject();
            Params.Add("parameter", "My param value");
            Params.Add("subject", "New Subject");
            List<string> Tags = new List<string>();
            Tags.Add("mytag");
            SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1(ToEmail, ToName);
            List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
            To1.Add(smtpEmailTo1);
            Dictionary<string, object> _parmas = new Dictionary<string, object>();
            _parmas.Add("params", Params);
            SendSmtpEmailReplyTo1 ReplyTo1 = new SendSmtpEmailReplyTo1(ReplyToEmail, ReplyToName);
            SendSmtpEmailMessageVersions messageVersion = new SendSmtpEmailMessageVersions(To1, _parmas, Bcc, Cc, ReplyTo1, Subject);
            List<SendSmtpEmailMessageVersions> messageVersiopns = new List<SendSmtpEmailMessageVersions>();
            messageVersiopns.Add(messageVersion);
            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Email, To, Bcc, Cc, HtmlContent, TextContent, Subject, ReplyTo, Attachment, Headers, TemplateId, Params, messageVersiopns, Tags);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            return true;
        }
        
        
    }
}

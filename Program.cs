using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IshaEmailer
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                SmtpClient mySmtpClient = new SmtpClient("dsrelay.hoffman.ds.adp.com");

                // set smtp-client with basicAuthentication
                //mySmtpClient.UseDefaultCredentials = false;
                //System.Net.NetworkCredential basicAuthenticationInfo = new
                //   System.Net.NetworkCredential("username", "password");
                //mySmtpClient.Credentials = basicAuthenticationInfo;
                var toList = ConfigurationManager.AppSettings["ToList"];
                var fromList = ConfigurationManager.AppSettings["From"];
                string[] strList = toList.Split(';');
                // add from,to mailaddresses
                MailAddress from = new MailAddress(fromList);

                MailMessage myMail = new System.Net.Mail.MailMessage();
                foreach (var temp in strList)
                {
                    myMail.To.Add(temp);
                }
                myMail.From = from;
                // set subject and encoding
                myMail.Subject = "Aamir Habib JEn Transfer Letter- Urgent on Vacant Post|Ref - RVPN(AS/ESTT-11/F.13(53D), 484 (13/09/2018 ";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "Respected Whomsoever, <br> Please find the attached Transfer letter for Aamir Habib.<br>Passowrd for the pdf is 123 <br><br> Thanks, <br> Energy Minister Rajasthan Government, <br> Sh. Pushpendra Singh,<br> Government of Rajasthan, <br>Government Secretariate,<br> Jaipur, Rajasthan";
                //myMail.Body = "<test.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.Attachments.Add(new Attachment("C:\\aamir letter\\AAMIRHABIB Transfer letter-Protected.pdf"));
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

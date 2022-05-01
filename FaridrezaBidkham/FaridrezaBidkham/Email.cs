using System.Text;

public class Email
{
    public async Task SendMessage(string To, string Subject, string Body)
    {
       await Task.Factory.StartNew(() =>
        {
            using (MailMessage mail = new MailMessage())
            {
                SmtpClient SmtpServer = new SmtpClient();
                mail.From = new MailAddress("FaridrezaSuported@outlook.com");
                mail.BodyEncoding = Encoding.UTF8;
                mail.To.Add(To);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.office365.com";
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Credentials = new System.Net.NetworkCredential("FaridrezaSuported@outlook.com", "jama832+28");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
        });
        
    }
}

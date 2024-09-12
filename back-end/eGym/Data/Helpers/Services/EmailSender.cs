using System.Net.Mail;
using System.Net;

namespace eGym.Data.Helpers.Services
{
    public class EmailSender
    {
        public void Posalji(string to)
        {
            string fromMail = "egymzalik@gmail.com";
            string fromPassword = "hcxrsjwktiidlxxb";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "eGym dobrodošlica";
            message.To.Add(new MailAddress(to));
            message.Body = "<html><body>Dobrodošli u našu teretanu! 🎉<br>" +
                "<br>Drago nam je što ste postali dio naše fitness zajednice. Ovdje vas čeka sjajna ekipa, motivirajuće okruženje i sve što vam je potrebno za postizanje vaših ciljeva. Bez obzira jeste li iskusni vježbač ili tek počinjete," +
                " tu smo da vam pomognemo na svakom koraku.<br>" +
                "<br>Prilikom prvog ulazka molimo Vas javite se osoblju radi izdavanja članske kartice. <br>" +
                "<br>Vidimo se u teretani! 💪</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);
        }

        public void Posalji2(string to,string Subject,string Body)
        {
            string fromMail = "egymzalik@gmail.com";
            string fromPassword = "hcxrsjwktiidlxxb";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = Subject;
            message.To.Add(new MailAddress(to));
            message.Body = Body;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ways.Model;
using Ways.ViewModel;

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wMailAdmin.xaml
    /// </summary>
    public partial class wMailAdmin : Window
    {
        private string message;
        private Candidate candidate;
        public wMailAdmin(string message)
        {
            InitializeComponent();
            Message = message;
            if(vmStart.emailAdmin == "")
            {
                tbMail.Text = "Exemple@Email.fr";
            }
            else
            {
                tbMail.Text = vmStart.emailAdmin;
            }
        }

        public wMailAdmin(string message, Candidate currentCandidate)
        {
            InitializeComponent();
            Message = message;
            Candidate = currentCandidate;
            tbMail.Text = "";
        }


        public string Message { get => message; set => message = value; }
        public Candidate Candidate { get => candidate; set => candidate = value; }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            View.wChoiceMenuAdmin pg = new View.wChoiceMenuAdmin();
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (tbMail.Text == "")
            {
                MessageBox.Show("Veuillez renseigner un mail");
            }
            else
            {
                switch (Message)
                {
                    case "ADMIN":
                        AddEmailAdmin(tbMail.Text);
                        View.wChoiceMenuAdmin pg = new View.wChoiceMenuAdmin();
                        pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        pg.Show();
                        this.Close();
                        break;
                    case "TESTORIENTATION":
                        //SendMail();
                        View.wResultOrientationCandidate pg2 = new View.wResultOrientationCandidate(Candidate);
                        pg2.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        pg2.Show();
                        this.Close();
                        break;
                    case "CONTACT":
                        //SendMail();
                        View.wScore pg3 = new View.wScore(Candidate);
                        pg3.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        pg3.Show();
                        this.Close();
                        break;
                }
            }
        }
        
        private void AddEmailAdmin(string mail)
        {
            vmStart.emailAdmin = mail;
        }

        private void SendMail()
        {
            switch (Message)
            {
                case "ORIENTATION":
                    var fromAddress = new MailAddress("projetsways2018@gmail.com", "Ways");
                    var toAddress = new MailAddress(tbMail.Text, "To Name");
                    const string fromPassword = "cesi_ways";
                    const string subject = "Subject";
                    const string body = "Body";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    break;
                    break;
                case "CONTACT":
                    break;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Mail;
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
using EASendMail; //Mailing
using System.Security.Cryptography.X509Certificates;

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wMailAdmin.xaml
    /// </summary>
    public partial class wEditMail : Window
    {
        private string message;
        private Candidate candidate;
        public wEditMail(string message)
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

        public wEditMail(string message, Candidate currentCandidate)
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
            View.wAdminMenu pg = new View.wAdminMenu();
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
                        View.wAdminMenu pg = new View.wAdminMenu();
                        pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        pg.Show();
                        this.Close();
                        break;
                    case "TESTORIENTATION":
                        SendMail();
                        View.wCandidateResultOrientation pg2 = new View.wCandidateResultOrientation(Candidate);
                        pg2.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        pg2.Show();
                        this.Close();
                        break;
                    case "CONTACT":
                        SendMail();
                        Candidate.UpPoints();
                        View.wCandidateResultGame pg3 = new View.wCandidateResultGame(Candidate);
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
            string subject = "";
            string textBody = "";


            switch (Message)
            {
                case "TESTORIENTATION":
                    Job job1 = vmStart.lstjobs[Candidate.OrientationPoints[0]];
                    Job job2 = vmStart.lstjobs[Candidate.OrientationPoints[1]];
                    Job job3 = vmStart.lstjobs[Candidate.OrientationPoints[2]];

                    subject = "Ways - Résultat de votre test d'orientation";
                    textBody = "Bonjour, " + Candidate.Surname + "\n";
                    textBody += "\n";
                    textBody += "Vous trouverez ci-dessous le résultat de votre test d'orientation effectué à l'évènement Journée Portes Ouvertes du CESI." + "\n";
                    textBody += "Nous vous souhaitons une bonne réception." + "\n";
                    textBody += "\n";

                    //1er job
                    textBody += "Métier : " + "\n";
                    textBody += job1.Name + "\n";
                    textBody += "Description : " + "\n";
                    textBody += job1.Des + "\n";
                    textBody += "Mission(s) : " + "\n";
                    foreach (string t in job1.Tasks)
                    {
                        textBody += t + "\n";
                    }
                    textBody += "\n";

                    //2eme job
                    textBody += "Métier : " + "\n";
                    textBody += job2.Name + "\n";
                    textBody += "Description : " + "\n";
                    textBody += job2.Des + "\n";
                    textBody += "Mission(s) : " + "\n";
                    foreach (string t in job2.Tasks)
                    {
                        textBody += t + "\n";
                    }
                    textBody += "\n";

                    //3eme job
                    textBody += "Métier : " + "\n";
                    textBody += job3.Name + "\n";
                    textBody += "Description : " + "\n";
                    textBody += job3.Des + "\n";
                    textBody += "Mission(s) : " + "\n";
                    foreach (string t in job3.Tasks)
                    {
                        textBody += t + "\n";
                    }
                    textBody += "\n";

                    textBody += "Cordialement" + "\n";
                    textBody += "\n";
                    textBody += "Ways";
                    break;
                case "CONTACT":
                    subject = "Ways - Invitation à l'évènement Journée Portes Ouvertes";
                    textBody = "Bonjour," + "\n";
                    textBody += "\n";
                    textBody += Candidate.Surname + " vous invite à participer à l'évènement Journée Portes Ouvertes du CESI qui se déroule aujourd'hui." + "\n";
                    textBody += "Cordialement" + "\n";
                    textBody += "\n";
                    textBody += "Ways";
                    break;
            }

            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = vmStart.emailAdmin;
                // Set recipient email address
                oMail.To = tbMail.Text;

                // Set email subject
                oMail.Subject = subject;
                // Set email body
                oMail.TextBody = textBody;

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = vmStart.emailAdmin;
                oServer.Password = "cesi_ways";

                // Set 465 port
                oServer.Port = 465;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                MessageBox.Show(ep.Message);
            }
        }
    }
}

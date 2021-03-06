﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ways.Model;
using Ways.ViewModel;

namespace Ways
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel.vmStart.getQuestionsGame();
            ViewModel.vmStart.getJobs();
            ViewModel.vmStart.getQuestionsOrientation();
        }

        private void btnCandidat_Click(object sender, RoutedEventArgs e)
        {
            if (vmStart.emailAdmin == "")
            {
                MessageBox.Show("Veuillez demander à l'administrateur de renseigner un Email");
            }
            else
            {
                View.wCandidateLogin pg = new View.wCandidateLogin();
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }

        }

        private void btnAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            View.wAdminLogin pgLoginAdmin = new View.wAdminLogin();
            pgLoginAdmin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pgLoginAdmin.Show();
            this.Close();
        }
    }
}

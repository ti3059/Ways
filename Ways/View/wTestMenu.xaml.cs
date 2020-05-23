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
using System.Windows.Shapes;
using Ways.Model;

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wAtestMenu.xaml
    /// </summary>
    public partial class wTestMenu : Window
    {
        private Candidate candidate;

        public wTestMenu(Candidate c)
        {
            InitializeComponent();
            candidate = c;
        }

        private void bOrientation_Click(object sender, RoutedEventArgs e)
        {
            Test_Orientation test_Orientation = new Test_Orientation(candidate);
            View.wQuestion pg = new View.wQuestion(test_Orientation);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void bGame_Click(object sender, RoutedEventArgs e)
        {
            //Test_Game ...
        }
    }
}

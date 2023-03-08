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
using ClassLibrary2;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            User.CreateAdmin();
        }

        private void log_Button_Click(object sender, RoutedEventArgs e)
        {
            User user = User.LogIn(login_TextBox.Text, password_PasswordBox.Password);
            if (user == null)
                MessageBox.Show("Wrong login or password");
            else
            {
                Hide();
                Journal journal = new Journal();
                journal.ShowDialog();
                Show();
            }
        }
    }
}

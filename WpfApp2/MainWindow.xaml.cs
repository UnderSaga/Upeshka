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
        }

        private void log_Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Entities())
            {
                var users = db.User.ToList().Where(User => User.UserName == login_TextBox.Text && User.Password == password_PasswordBox.Password);
                if (users.Count() == 0)
                    MessageBox.Show("Wrong login or password");
                else
                {
                    Session.CurrentUser = users.First();
                    Hide();
                    Log journal = new Log();
                    journal.ShowDialog();
                    Show();
                }
            }
        }
    }
}

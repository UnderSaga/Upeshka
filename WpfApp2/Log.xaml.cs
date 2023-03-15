using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Journal.xaml
    /// </summary>
    public partial class Log : Window
    {
        public Log()
        {
            InitializeComponent();
            using (var db = new Entities())
            {
                Session.CurrentUser.Journal.ToList().ForEach(j => groups.Items.Add(j.Group1));
            }    
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            groups.Items.Clear();
            using (var db = new Entities())
            {
                db.Group.ToList().ForEach(group =>
                {
                    if(group.Name.Contains(filterTextBox.Text))
                        groups.Items.Add(group);
                });
            }
        }
        private void groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Session.CurrentGroup = groups.SelectedItem as Group;
            GroupWindow groupWindow = new GroupWindow();
            Hide();
            groupWindow.ShowDialog();
            Show();
        }
    }
}

using System;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public GroupWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            disciplines.Items.Clear();
            using (var db = new Entities()) 
            { 
                Session.CurrentGroup.Journal.Where(Journal => Journal.Group1 == Session.CurrentGroup).ToList().ForEach(Journal => disciplines.Items.Add(Journal.Discipline1));
                Session.CurrentGroup.Student.ToList().ForEach(s => students.Items.Add(s));
            }
        }
        private void disciplines_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Session.CurrentDiscipline = disciplines.SelectedItem as Discipline;
            JournalWindow log = new JournalWindow();
            Hide();
            log.ShowDialog();
            Show();
        }
    }
}

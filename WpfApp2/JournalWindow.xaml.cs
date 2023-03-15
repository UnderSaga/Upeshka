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
    /// Логика взаимодействия для DataBase.xaml
    /// </summary>
    public partial class JournalWindow : Window
    {
        public JournalWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object seneder, RoutedEventArgs e)
        {
            DataGridColumn dataGridColumn = new DataGridTemplateColumn
            {
                Header = "Студент",
                CellTemplate = new DataTemplate(new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    DataContext = new Binding("Student")
                })
            };
            JournalGrid.Columns.Add(dataGridColumn);
            using(var db = new Entities())
            {
                Session.CurrentJurnal = db.Journal.Where(j =>
                j.Group1 == Session.CurrentGroup &&
                j.User == Session.CurrentUser &&
                j.Discipline1 == Session.CurrentDiscipline).First();
                Session.CurrentJurnal.Lesson.ToList().ForEach(l =>
                {
                    JournalGrid.Columns.Add(new DataGridTemplateColumn
                    {
                        Header = l.Date
                    });
                });
                Session.CurrentGroup.Student.ToList().ForEach(s =>
                {
                    JournalGrid.Items.Add(s);
                });
            }
        }
    }
}

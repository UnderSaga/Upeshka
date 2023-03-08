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
using ClassLibrary2;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        public ObservableCollection<Grop> Grops = new ObservableCollection<Grop>();
        public Journal()
        {
            InitializeComponent();
            using (var db = new DBContext())
            {
                List<Grop> GropList = db.Grops.ToList();
                foreach(Grop group in GropList)
                {
                    groups.Items.Add(group);
                }
            }    
        }
    }
}

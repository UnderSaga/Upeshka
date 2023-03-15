using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Session
    {
        public static User CurrentUser { get; set; }
        public static Group CurrentGroup { get; set; }
        public static Lesson CurrentLesson { get; set; }
        public static Discipline CurrentDiscipline { get; set; }
        public static Journal CurrentJurnal { get; set; }
    }
}

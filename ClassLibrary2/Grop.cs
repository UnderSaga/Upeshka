using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Grop
    {
        public int Id { get; set; }
        public Special Special { get; set; }
        public int SubGroup { get; set; }
        public int ClassRoom { get; set; }
        public int StartYear { get; set; }
        public string Name { get; set; }

        public string GetCode()
        {
            int kourse = DateTime.Now.Year - StartYear;
            if (DateTime.Now.Month >= 9)
                kourse++;
            return $"{kourse}-{SubGroup}{Special.Code}{ClassRoom}";
        }
    }
}

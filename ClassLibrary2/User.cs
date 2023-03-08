using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClassLibrary2
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public static void CreateAdmin()
        {
            using (var db = new DBContext())
            {
                db.Database.Delete();
                var user = new User { Login = "Admin", PasswordHash = "Admin" };
                db.Users.Add(user);
                Special special = new Special { Code = "П", Name = "Программисты"};
                db.Specials.Add(special);
                for (int i = 0; i < 4; i++)
                {
                    for (int sg = 1; sg < 3; sg++)
                    {
                        Grop grop = new Grop
                        {
                            ClassRoom = 9,
                            SubGroup = sg,
                            StartYear = 2019 + i,
                            Special = special
                        };
                        grop.Name = grop.GetCode();
                        db.Grops.Add(grop);
                    }
                }
                db.SaveChanges();
            }
        }
        public static User LogIn(string login, string password)
        {
            using (var db = new DBContext())
            {
                try
                {
                    return db.Users.Where(u => u.Login == login && u.PasswordHash == password).First();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

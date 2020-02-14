using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreMVC.Models.DBModels;

namespace WebCoreMVC.Models.DBContext.InitializeDB
{
    public class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            bool reInit = true;
            if(reInit)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 550
                    },
                    new Phone
                    {
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }

            if (!context.Companies.Any())
            {
                Company oracle = new Company { Name = "Oracle" };
                Company google = new Company { Name = "Google" };
                Company microsoft = new Company { Name = "Microsoft" };
                Company apple = new Company { Name = "Apple" };

                //User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
                //User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
                //User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
                //User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
                //User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
                //User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
                //User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
                //User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

                User user1 = new User { Name = "Олег Васильев", Age = 26 };
                User user2 = new User { Name = "Александр Овсов", Age = 24 };
                User user3 = new User { Name = "Алексей Петров", Age = 25 };
                User user4 = new User { Name = "Иван Иванов", Age = 26 };
                User user5 = new User { Name = "Петр Андреев", Age = 23 };
                User user6 = new User { Name = "Василий Иванов", Age = 23 };
                User user7 = new User { Name = "Олег Кузнецов", Age = 25 };
                User user8 = new User { Name = "Андрей Петров", Age = 24 };





                context.Companies.AddRange(oracle, microsoft, google, apple);
                context.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
                context.SaveChanges();
            }
        }
    }
}

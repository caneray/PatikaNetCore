using System.Linq;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize() //class adıyla erişmek istiyorum. static o yüzden.
        {
            using(var context = new LinqDbContext())
            {
                if(context.Students.Any()) // bu listede hiç veri varmı? studentda veri var mı?
                {
                    return;
                }

                context.Students.AddRange(
                    new Student()
                    {
                        Name = "Caner",
                        Surname = "Ay",
                        ClassId = 1
                    },
                    new Student()
                    {
                        Name = "Çağla",
                        Surname = "Şılak",
                        ClassId = 1
                    },
                    new Student(){
                        Name = "Buse",
                        Surname = "Ay",
                        ClassId = 2
                    },
                    new Student(){
                        Name = "Ali",
                        Surname = "Ay",
                        ClassId = 2
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
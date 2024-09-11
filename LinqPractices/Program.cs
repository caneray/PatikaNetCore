using System;
using System.Linq;
using LinqPractices.DbOperations;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>(); //Öğrencileri Listeler

            //Find() -> 

            System.Console.WriteLine("******* Find *******");
            var student = _context.Students.Where(student => student.StudentId ==1).FirstOrDefault();
            student = _context.Students.Find(2);
            System.Console.WriteLine(student.Name);

                    // Verilen dbset içerisinde primary key olarak işaretlenmiş olan alana göre basit bir yapıyla arama işlemi yapar

            // FirstOrDefault()
            System.Console.WriteLine();
            System.Console.WriteLine("******* FirstOrDefault *******");
            student = _context.Students.Where(student => student.Surname == "Ay").FirstOrDefault(); //kendisine gelen çoklu veri setinden birden fazla veri gelirse onun ilkini getirir.
            System.Console.WriteLine(student.Name);

            student = _context.Students.FirstOrDefault(x => x.Surname == "Ay"); //yukarıdakiyle aynı işlemi gerçekleştirir. Daha okunabilir.
            System.Console.WriteLine(student.Name);

                    // FirstOrDefault ile First in farkı
                    // First ile yine veriyi bulur fakat aradığı seçenekte hiçbir eleman yoksa hata fırlatır. FirstOrDefault ile null döner.
            
            // SingleOrDefault()
            System.Console.WriteLine();
            System.Console.WriteLine("******* SingleOrDefault *******");
            student = _context.Students.SingleOrDefault(student => student.Name == "Caner");
            System.Console.WriteLine(student.Surname);
                    
                    // Sadece aranılan veriden tek bir tane varsa döndürür. İki tane varsa hata gönderir.
                    // student = _context.Students.SingleOrDefault(student => student.Surname == "Ay");
                    // yukarıdaki kodda hata verir. Çünkü in memory dbde 2 tane ay olan veri var.

            // ToList()
            System.Console.WriteLine();
            System.Console.WriteLine("******* ToList *******");
            var studentList = _context.Students.Where(student => student.ClassId == 2).ToList(); //Class Idsi kaç eleman varsa getir.
            System.Console.WriteLine(studentList.Count()); // Bu elemanlardan kaç tane var onu listeler.

            // OrderBy()
            System.Console.WriteLine();
            System.Console.WriteLine("******* OrderBy *******");
            students = _context.Students.OrderBy(x => x.StudentId).ToList();
            foreach (var st in students)
            {
                System.Console.WriteLine(st.StudentId + " - " + st.Name + " " + st.Surname);
            }
                    // Artan sırada listele

            // OrderByDescending()
            System.Console.WriteLine();
            System.Console.WriteLine("******* OrderByDescending *******");
            students = _context.Students.OrderByDescending(x => x.StudentId).ToList();
            foreach (var st in students)
            {
                System.Console.WriteLine(st.StudentId + " - " + st.Name + " " + st.Surname);
            }
                    // Azalan sırada listele

            // Anonymous Object Result
            System.Console.WriteLine();
            System.Console.WriteLine("******* Anonymous Object Result *******");

            var anonymousObject = _context.Students
                                .Where(x => x.ClassId == 2)
                                .Select(x => new{ //yeni bir obje yaratma
                                    Id = x.StudentId,
                                    FullName = x.Name + " " + x.Surname
                                });

            foreach (var obj in anonymousObject)
            {
                System.Console.WriteLine(obj.Id + " - " + obj.FullName);
            }
        }

    }
}

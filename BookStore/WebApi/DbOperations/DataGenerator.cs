using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initiliaze(IServiceProvider serviceProvider)
        {
            //program her çalıştığında ayağa kaldır ve içinde veri yoksa bu 3 tane veri kesinlikle olsun.
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange( //n tane veriyi eklemek
                    new Book{
                       // Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, // Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12)
                    },
                    new Book{
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2, // Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,23)
                    },
                    new Book{
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2, // Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2002,12,23)
                    }
                );

                context.SaveChanges(); //3 veri ekledim bunları kaydet.
            }
        }
    }
}
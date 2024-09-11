
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //bunu vererek otomatik olarak kendinin artmasını sağlıyoruz.
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; } //kitap türü
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
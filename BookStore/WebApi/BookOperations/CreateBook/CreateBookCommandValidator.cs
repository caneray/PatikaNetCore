using System;
using System.Data;
using FluentValidation;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand> //validator classı createbookcommandı valide eder. Onun objelerini valide eder.
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0); //0 dan daha büyük olması gerektiğini söyler. Burada GenreId 0dan büyük olmak zorunda demektir.
            RuleFor(command => command.Model.PageCount).GreaterThan(0); // Sayfa sayısı 0dan büyük olsun
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);//bugünden daha küçük olmalı. ve tarih boş olmamalı
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4); // Kitabın adı minimum 4 karakter olabilir.
        }
    }
}
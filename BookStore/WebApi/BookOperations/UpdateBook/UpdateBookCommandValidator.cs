using System;
using System.Data;
using FluentValidation;
using WebApi.BookOperations.UpdateBook;

namespace WebApi.BookOperations.GetBookDetail
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand> //validator classı createbookcommandı valide eder. Onun objelerini valide eder.
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0); //0 dan daha büyük olması gerektiğini söyler. Burada GenreId 0dan büyük olmak zorunda demektir.
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4); // Kitabın adı minimum 4 karakter olabilir.
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
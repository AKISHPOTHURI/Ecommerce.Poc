namespace Ecommerce.Api.ModelDTO
{
    using FluentValidation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class ProductsDTOValidations : AbstractValidator<ProductsColumnsDTO>
    {
        readonly Regex regOnlyLetters = new Regex("^[a-zA-Z ]+$");
        public ProductsDTOValidations()
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop)
                .NotEqual(0).WithMessage("product Id cannot be empty or 0. ")
        .       GreaterThanOrEqualTo(0).WithMessage("product Id is not valid. ");

            RuleFor(x => x.SellerId).Cascade(CascadeMode.Stop)
                    .NotEqual(0).WithMessage("seller Id cannot be empty or 0. ")
                    .GreaterThanOrEqualTo(0).WithMessage("seller Id is not valid. ");

            RuleFor(x => x.ProductName).Cascade(CascadeMode.Stop)
                    .NotNull().WithMessage("product Name cannot be empty. ")
                    .Length(1, 50).WithMessage("product Name should not be more than 50 characters. ");
                    //.Matches(regOnlyLetters).WithMessage("product Name must contain only alphabets. ");

            RuleFor(x => x.Price).Cascade(CascadeMode.Stop)
                     .NotEqual(0).WithMessage("price cannot be empty or 0. ")
                     .GreaterThanOrEqualTo(0).WithMessage("price is not valid. ");

            RuleFor(x => x.Colour).Cascade(CascadeMode.Stop)
                     .NotEqual(0).WithMessage("colour Id cannot be empty or 0. ")
                     .GreaterThanOrEqualTo(0).WithMessage("colour Id is not valid. ");

            RuleFor(x => x.Category).Cascade(CascadeMode.Stop)
                     .NotEqual(0).WithMessage("category Id cannot be empty or 0. ")
                     .GreaterThanOrEqualTo(0).WithMessage("category Id is not valid. ");

            //RuleFor(x => x.).Cascade(CascadeMode.Stop)
            //         .NotNull().WithMessage("Seller Name cannot be empty. ")
            //         .Length(1, 50).WithMessage("category should not be more than 50 characters. ")
            //         .Matches(regOnlyLetters).WithMessage("category must contain only alphabets. ");

            RuleFor(x => x.ProductDescription).Cascade(CascadeMode.Stop)
                     .NotNull().WithMessage("description cannot be empty. ")
                     .Length(1, 50).WithMessage("description should not be more than 50 characters. ")
                     .Matches(regOnlyLetters).WithMessage("description must contain only alphabets. ");

            RuleFor(x => x.ProductImage).Cascade(CascadeMode.Stop)
                     .NotNull().WithMessage("image cannot be empty. ")
                     .Length(1, 100).WithMessage("image should not be more than 50 characters. ");
                     //.Matches(regOnlyLetters).WithMessage("image must contain only alphabets. ");
        }

    }
}

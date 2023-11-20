using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator() 
        { 
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçilemez");
            RuleFor(x=>x.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçilemez");
            RuleFor(x=>x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
            RuleFor(x=>x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 4 karakterden daha fazla veri girişi yapın");
            //RuleFor(x => x.BlogContent).MaximumLength(1000).WithMessage("Lütfen 500 karakterden daha az veri girişi yapın");
            RuleFor(x => x.BlogContent).MinimumLength(10).WithMessage("Lütfen 10 karakterden daha fazla veri girişi yapın");

        }
    }
}

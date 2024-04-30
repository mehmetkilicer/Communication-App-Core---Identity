using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppUserValidation
{
    public class CreateUserValidation :AbstractValidator<AppUser>
    {
        public CreateUserValidation() 
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Bu Alanı Bos Gecemesssiniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu Alanı Bos Gecemesssiniz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Gecerli bir mail adresi giriniz");
            RuleFor(x => x.Department).NotEmpty().WithMessage("Bulundugunuz Departmanı Seciniz");


        }
    }
}

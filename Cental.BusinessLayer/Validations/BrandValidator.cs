using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validations
{
    //FluentValidation -> Kutuphane mıras almak.
    public class BrandValidator : AbstractValidator<CarBrand>
    {
        //Mesaj / uyarı .
        public BrandValidator()
        {
            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("Marka ismi Boş bırakılmaz.")
                .MinimumLength(3).WithMessage("Marka ismi en az 3 karakter olmalıdıra");
                //.EmailAddress;
                
        }
    }
}

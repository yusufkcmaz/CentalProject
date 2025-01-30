using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validations
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(X=> X.ModelName).NotEmpty().
                 WithMessage("Araba Modeli Boş Geçilemez");

            RuleFor(x => x.KM).NotEmpty().
                 WithMessage("KM Doğru yazılmalıdır ");

            RuleFor(x => x.Transmission).NotEmpty().
                WithMessage("Vites Türü Boş Geçilemez");

            RuleFor(x => x.Year).NotEmpty().
                WithMessage("Model Yılı Boş Geçilemez");

            RuleFor(x => x.GasType).NotEmpty().
               WithMessage("Yakıt Türü Boş Geçilemez");

            RuleFor(x => x.GearType).NotEmpty().
               WithMessage("Vites Türü Boş Geçilemez");

            RuleFor(x => x.SeatCount).NotEmpty().
               WithMessage("Koltuk Sayısı Boş Geçilemez");
        }
    }
    
} 

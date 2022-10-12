using EntityLayer.DTOs.SectorDTOs;
using FluentValidation;

namespace ExamProject.ValidationRules
{
    public class SectorValidatior : AbstractValidator<SectorToAddOrUpdateDTO>
    {
        public SectorValidatior()
        {
            RuleFor(x => x.SectorName).MinimumLength(5).WithMessage("min length must be 5 characters");
            RuleFor(x => x.SectorName).NotNull().WithMessage("can not be null");
        }
    }
    }


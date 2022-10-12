using EntityLayer.DTOs.DepartmentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.ValidationRules
{
    public class DepartmentValidatior:
   AbstractValidator<DepartmentToAddOrUpdateDTO>
    {
        public DepartmentValidatior()
        {
            RuleFor(x => x.DepartmentName).MinimumLength(3).WithMessage("min length must be 3");
            RuleFor(x => x.DepartmentName).NotNull().WithMessage("can not be null");

        }
}
}


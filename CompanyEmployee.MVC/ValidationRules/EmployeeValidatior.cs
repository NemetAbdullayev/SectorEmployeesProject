using EntityLayer.DTOs.EmployeeDTOs;
using FluentValidation;


namespace ExamProject.ValidationRules
{
    public class EmployeeValidatior:AbstractValidator<EmployeeToAddOrUpdateDTO>
    {
        public EmployeeValidatior()
        {
            RuleFor(x => x.EmpName).MinimumLength(3).WithMessage("Min length must be 3 characters");
            RuleFor(x => x.Surname).MaximumLength(25).WithMessage("Max length must be 25 character");
            RuleFor(x => x.EmpName).NotNull().WithMessage("can not be null");
            RuleFor(x => x.Surname).NotNull().WithMessage("can not be null");


        }
    }
}

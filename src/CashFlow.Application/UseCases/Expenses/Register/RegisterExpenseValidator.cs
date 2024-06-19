using FluentValidation;
using CashFlow.Communication.Requests;      

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title)
                .NotEmpty()
                .WithMessage("The title is required.");

            RuleFor(expense => expense.Amount)
                .GreaterThan(0)
                .WithMessage("The amount must be greater than 0.");

            RuleFor(expense => expense.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Expenses must be in the past, not in the future.");

            RuleFor(expense => expense.PaymentType)
                .IsInEnum()
                .WithMessage("Payment type is not valid, must be between 0 and 4");
        }
    }
}

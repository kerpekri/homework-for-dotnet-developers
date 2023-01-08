using EG.Homework.Orders.Models;
using FluentValidation;

namespace EG.Homework.Orders.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrder>
{
    private const int MaxAllowedKitAmount = 1000;

    public CreateOrderValidator()
    {
        RuleFor(ord => ord.Amount)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Desired amount is not positive number")
            .Must(BeRoundNumber)
            .WithMessage("Desired amount must be a round number")
            .LessThan(MaxAllowedKitAmount)
            .WithMessage($"Desired amount must be less than {MaxAllowedKitAmount}");

        RuleFor(ord => ord.CustomerId)
            .NotEmpty();

        RuleFor(ord => ord.ExpectedDeliveryDate)
            .NotEmpty()
            .Must(BeInFuture)
            .WithMessage("Delivery date must be in the future.");
    }

    private static bool BeRoundNumber(decimal value) => value % 1 == 0;

    private static bool BeInFuture(DateTime value) => value > DateTime.UtcNow;
}
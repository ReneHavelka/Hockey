using Domain.Common;
using FluentValidation;

namespace Application.Common.Validators
{
    internal class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator(Player player)
        {
            var minimumDay = DateOnly.FromDateTime(DateTime.Now.AddYears(-50));
            var todayDay = DateOnly.FromDateTime(DateTime.Now.AddYears(-7));

            RuleFor(player => player.Name)
                .NotEmpty().WithMessage("No name");
            RuleFor(player => player.Surname)
                .NotEmpty().WithMessage("No surname");
            RuleFor(player => player.DateOfBirth)
                .GreaterThanOrEqualTo(minimumDay).WithMessage("Date too early")
                .LessThanOrEqualTo(todayDay).WithMessage("Date too late");
        }

        public string PlayerValidate(Player player)
        {
            try
            {
                this.ValidateAndThrow(player);
            }
            catch
            {
                throw;
            }

            return String.Empty;
        }
    }
}

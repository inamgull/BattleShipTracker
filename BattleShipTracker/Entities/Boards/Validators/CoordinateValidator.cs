using FluentValidation;

namespace BattleShipTracker.Entities.Boards.Validators
{
    public class CoordinateValidator : AbstractValidator<Coordinates>
    {
        public CoordinateValidator()
        {
            RuleFor(x => x.Column).GreaterThanOrEqualTo(0).LessThan(10);
            RuleFor(x => x.Row).GreaterThanOrEqualTo(0).LessThan(10);
        }
    }
}

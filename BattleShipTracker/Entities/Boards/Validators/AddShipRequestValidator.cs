using BattleShipTracker.Entities.Ships.Requests;
using FluentValidation;

namespace BattleShipTracker.Entities.Boards.Validators
{
    public class AddShipRequestValidator : AbstractValidator<AddShipRequest>
    {
        public AddShipRequestValidator()
        {
            RuleFor(x => x.Origin).SetValidator(new CoordinateValidator());
            
            RuleFor(x => x.Ship).NotNull();
        }
    }
}

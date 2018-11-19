using FluentValidation;

namespace BattleShipTracker.Entities.Boards.Validators
{
    public class MarkingBoardSqaureStatusValidator : AbstractValidator<SquareStatus>
    {
        public MarkingBoardSqaureStatusValidator()
        {
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x != SquareStatus.Available || x != SquareStatus.Marked)
                {
                    context.AddFailure("Square status can only be hit or miss");
                }
            });
        }
    }
}

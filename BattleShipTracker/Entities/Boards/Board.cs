namespace BattleShipTracker.Entities.Boards
{
    //Abstract base class for different types of boards. Each board has 10 rows and 10 columns
    public abstract class Board
    {
        protected const int Rows = 10;
        protected const int Cols = 10;

        protected Square[,] Squares = new Square[Rows, Cols];

        protected Board()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Cols; col++)
                {
                    Squares[row, col] = new Square(new Coordinates(row, col));
                }
            }

        }
    }
}

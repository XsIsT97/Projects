﻿namespace ChessLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        private readonly Direction forword;

        public Pawn(Player color)
        {
            Color = color;

            if (color == Player.White)
            {
                forword = Direction.North;
            }
            else if (color == Player.Black)
            {
                forword = Direction.South;
            }
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInside(pos) || board.IsEmpty(pos);
        }

        private bool CanCapture(Position pos, Board board)
        {
            if (!Board.IsInside(pos) || board.IsEmpty(pos))
            {
                return false;
            }

            return board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMove(Position from, Board board)
        {
            Position oneMovePos = from + forword;

            if (CanMoveTo(oneMovePos, board))
            {
                yield return new NormalMove(from, oneMovePos);

                Position twoMovePos = oneMovePos + forword;

                if (!HasMoved && CanMoveTo(twoMovePos, board))
                {
                    yield return new NormalMove(from, twoMovePos);
                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
            {
                Position to = from + forword + dir;

                if (CanCapture(to, board))
                {
                    yield return new NormalMove(from, to);
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMove(from, board).Concat(DiagonalMoves(from, board));
        }
    }
}

using System;
using System.Threading;

namespace Task8.Initializers
{
    class SpiralArrayInitializer
    {
        private const int PrintInterval = 4;

        private int _counter;
        private Point? _currentPosition;
        private Direction _currentDirection;

        public SpiralArrayInitializer(int[,]array)
        {
            this.Array = array ?? throw new NullReferenceException(nameof(array));

            this._currentPosition = new Point(0, 0);
            this._currentDirection = Direction.Right;
        }

        public int[,] Array { get; set; }

        public bool TryFill()
        {
            if (this.Array == null
             || this.Array.GetLength(0) < 1 
             || this.Array.GetLength(1) < 1)
            {
                return false;
            }
            var position = this._currentPosition;
            while(position != null)
            {
                this._counter++;
                this.Array[position.Value.Row, position.Value.Column] = _counter;
                PrintElement(this._counter, position);
                this._currentPosition = position;
                Thread.Sleep(100);
                position = GetFreePosition();
            }
            return true;
        }

        private Point? GetFreePosition()
        {
            switch (this._currentDirection)
            {
                case Direction.Up:
                    return GetPosition(new Point(this._currentPosition.Value.Row - 1, this._currentPosition.Value.Column),
                                            new Point(this._currentPosition.Value.Row, this._currentPosition.Value.Column + 1));
                case Direction.Right:
                    return GetPosition(new Point(this._currentPosition.Value.Row, this._currentPosition.Value.Column + 1),
                                            new Point(this._currentPosition.Value.Row + 1, this._currentPosition.Value.Column));
                case Direction.Down:
                    return GetPosition(new Point(this._currentPosition.Value.Row + 1, this._currentPosition.Value.Column),
                                            new Point(this._currentPosition.Value.Row, this._currentPosition.Value.Column - 1));
                case Direction.Left:
                    return GetPosition(new Point(this._currentPosition.Value.Row, this._currentPosition.Value.Column - 1),
                                            new Point(this._currentPosition.Value.Row - 1, this._currentPosition.Value.Column)); 
                default:
                    return null;
            }


        }

        private Point? GetPosition(Point point, Point emergencyPoint)
        {
            if (IsFree(point))
            {
                return point;
            }
            else
            {
                ChangeDirection();
            }
            if (IsFree(emergencyPoint))
            {
                return emergencyPoint;
            }

            return null;
        }

        private bool IsFree(Point? position)
        {
            return position.Value.Row < this.Array.GetLength(0)
                && position.Value.Row >= 0
                && position.Value.Column < this.Array.GetLength(1)
                && position.Value.Column >= 0
                && this.Array[position.Value.Row, position.Value.Column] == default;
        }

        private void ChangeDirection()
        {
            switch (this._currentDirection)
            {
                case Direction.Up:
                    this._currentDirection = Direction.Right;
                    return;
                case Direction.Right:
                    this._currentDirection = Direction.Down;
                    return;
                case Direction.Down:
                    this._currentDirection = Direction.Left;
                    return;
                case Direction.Left:
                    this._currentDirection = Direction.Up;
                    return;
                default:
                    return;
            }
        }

        private void PrintElement(int elem, Point? position)
        { 
            Console.SetCursorPosition(position.Value.Column * PrintInterval, position.Value.Row * PrintInterval);
            Console.Write(elem);
        }
    }
}

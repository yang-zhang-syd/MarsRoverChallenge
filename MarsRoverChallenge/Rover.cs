using MarsRoverChallenge.Commands;

namespace MarsRoverChallenge
{
    public class Rover
    {
        private const string _directions = "NESW";
        private readonly RoverCommandFactory _roverCommandFactory;

        private int _facingDirectionIndex;

        public Rover(int x, int y, char facing, int[] dimentions)
        {
            X = x;
            Y = y;
            Facing = facing;

            _facingDirectionIndex = _directions.IndexOf(facing);
            _roverCommandFactory = new RoverCommandFactory(this, dimentions);
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char Facing { get; private set; }

        /// <summary>
        /// If set to true, rover will not go beyond boundries defined by dimensions.
        /// </summary>
        public bool AvoidGoBeyondBoundaries { get; set; }

        public void Run(char instruction)
        {
            var command = _roverCommandFactory.GetCommand(instruction);
            command?.Run(instruction);
        }

        public void TurnLeft()
        {
            var length = _directions.Length;
            _facingDirectionIndex = (_facingDirectionIndex - 1) % length;

            if (_facingDirectionIndex < 0)
            {
                _facingDirectionIndex += length;
            }

            Facing = _directions[_facingDirectionIndex];
        }

        public void TurnRight()
        {
            var length = _directions.Length;
            _facingDirectionIndex = (_facingDirectionIndex + 1) % length;

            Facing = _directions[_facingDirectionIndex];
        }
    }
}

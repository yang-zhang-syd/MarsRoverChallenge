namespace MarsRoverChallenge.Commands
{
    class MoveCommand : ICommand
    {
        private Rover _rover;
        private char _instruction;
        private int[] _dimentions;

        public MoveCommand(Rover rover, int[] dimentions, char instruction)
        {
            _rover = rover;
            _instruction = instruction;
            _dimentions = dimentions;
        }

        public void Run(char instruction)
        {
            moveOneStep();
        }

        private bool isValidMove()
        {
            if (_rover.Facing == 'N')
            {
                return _rover.Y + 1 <= _dimentions[1] || !_rover.AvoidGoBeyondBoundaries;
            }
            else if (_rover.Facing == 'S')
            {
                return _rover.Y - 1 >= 0 || !_rover.AvoidGoBeyondBoundaries;
            }
            else if (_rover.Facing == 'E')
            {
                return _rover.X + 1 <= _dimentions[0] || !_rover.AvoidGoBeyondBoundaries;
            }
            else if (_rover.Facing == 'W')
            {
                return _rover.X - 1 >= 0 || !_rover.AvoidGoBeyondBoundaries;
            }

            return false;
        }

        private void moveOneStep()
        {
            if (!isValidMove())
            {
                return;
            }

            if (_rover.Facing == 'N')
            {
                _rover.Y += 1;
            }
            else if (_rover.Facing == 'S')
            {
                _rover.Y -= 1;
            }
            else if (_rover.Facing == 'E')
            {
                _rover.X += 1;
            }
            else if (_rover.Facing == 'W')
            {
                _rover.X -= 1;
            }
        }
    }
}

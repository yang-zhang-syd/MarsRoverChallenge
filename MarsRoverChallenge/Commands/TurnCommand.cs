namespace MarsRoverChallenge.Commands
{
    public class TurnCommand : ICommand
    {
        private readonly Rover _rover;

        public TurnCommand(Rover rover)
        {
            _rover = rover;
        }

        public void Run(char instruction)
        {
            if (instruction == 'L')
            {
                _rover.TurnLeft();
            }
            else if (instruction == 'R')
            {
                _rover.TurnRight();
            }
        }
    }
}

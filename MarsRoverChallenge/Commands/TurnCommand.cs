namespace MarsRoverChallenge.Commands
{
    public class TurnCommand : ICommand
    {
        private Rover _rover;
        private char _instruction;

        public TurnCommand(Rover rover, char instruction)
        {
            _rover = rover;
            _instruction = instruction;
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

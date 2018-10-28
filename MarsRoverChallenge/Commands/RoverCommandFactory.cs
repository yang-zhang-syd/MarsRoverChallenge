using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Commands
{
    public class RoverCommandFactory
    {
        private readonly Rover _rover;
        private readonly int[] _dimentions;

        public RoverCommandFactory(Rover rover, int[] dimentions)
        {
            _rover = rover;
            _dimentions = dimentions;
        }

        public ICommand GetCommand(char instruction)
        {
            if (instruction == 'M')
            {
                return new MoveCommand(_rover, _dimentions);
            }
            else if (instruction == 'L' || instruction == 'R')
            {
                return new TurnCommand(_rover);
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Commands
{
    public interface ICommand
    {
        void Run(char instruction);
    }
}
